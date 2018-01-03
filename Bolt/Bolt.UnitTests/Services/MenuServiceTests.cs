namespace Bolt.UnitTests.Services
{
    using System;
    using System.Threading.Tasks;

    using Moq;
    using Xunit;
    using FluentAssertions;

    using Data.Contexts.Bolt.Core.Repositories;

    public class MenuServiceTests
    {
        [Fact]
        public async Task GetMenuAsync_GivenValidScenario_ShouldNotThrowAnException()
        {
            IMenuRepository menuRepositoryMock = new Mock<IMenuRepository>().Object;

            Action action = async () => await menuRepositoryMock.GetMenuAsync();

            action.Should().NotThrow();
        }

        [Fact]
        public async Task GetMenuAsync_WhenTheRepositoryThrowsAnException_ShouldThrowProperException()
        {
            var menuRepositoryMock = new Mock<IMenuRepository>();
            menuRepositoryMock.Setup(x => x.GetMenuAsync())
                .ThrowsAsync(new ArgumentException("Unable to get the repo."));

            IMenuRepository menuRepositoryObject = menuRepositoryMock.Object;

            Action action = async () => await menuRepositoryObject.GetMenuAsync();

            action.Should().Throw<ArgumentException>();
        }
    }
}
