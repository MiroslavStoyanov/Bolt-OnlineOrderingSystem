namespace Bolt.UnitTests
{
    using System;
    using System.Threading.Tasks;

    using Moq;
    using Xunit;
    using FluentAssertions;

    using Services.Implementations;
    using Data.Contexts.Bolt.Core.Repositories;

    public class MenuServiceTests
    {
        [Fact]
        public async Task GetMenuAsync_WhenMenuDTOIsValid_ShouldNotThrowAnException()
        {
            IMenuRepository menuRepository = new Mock<IMenuRepository>().Object;

            var menuService = new MenuService(menuRepository);

            Action action = async () => await menuService.GetMenuAsync();

            action.Should().NotThrow();

            Assert.True(true);
        }
    }
}
