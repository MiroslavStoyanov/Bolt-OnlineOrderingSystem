namespace Bolt.UnitTests.Services
{
    using System;
    using System.Threading.Tasks;

    using Moq;
    using Xunit;
    using FluentAssertions;

    using Core.Data.Repositories;
    using Data.Contexts.Bolt.Core;
    using Bolt.Services.Implementations;

    public class MenuServiceTests
    {
        [Fact]
        public async Task GetMenuAsync_GivenValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> menuRepositoryMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            var service = new MenuService(menuRepositoryMock);

            Action action = async () => await service.GetMenuAsync();

            action.Should().NotThrow();
        }

        //[Fact]
        //public async Task GetMenuAsync_WhenTheRepositoryThrowsAnException_ShouldThrowProperException()
        //{
        //    var exceptionToThrow = new ArgumentException();

        //    IUnitOfWork<IBoltDbContext> menuRepositoryMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;
        //    menuRepositoryMock.Setup(x => x.GetMenuAsync())
        //        .Callback(() => throw exceptionToThrow);

        //    IMenuRepository menuRepositoryObject = menuRepositoryMock.Object;

        //    var service = new MenuService(menuRepositoryObject);

        //    service
        //        .Awaiting(async sut => await sut.GetMenuAsync())
        //        .Should()
        //        .ThrowExactly<ArgumentException>()
        //        .WithMessage("Something went wrong while getting the menu.")
        //        .WithInnerException<Exception>();
        //}
    }
}
