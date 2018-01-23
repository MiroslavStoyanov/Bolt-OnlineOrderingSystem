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
    using Data.Contexts.Bolt.Core.Repositories;
    using Bolt.Services.ExceptionHandling.Exceptions;

    public class MenuServiceTests
    {
        #region GetMenuAsync

        [Fact]
        public async Task GetMenuAsync_GivenValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> menuRepositoryMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            var service = new MenuService(menuRepositoryMock);

            Action action = async () => await service.GetMenuAsync();

            action.Should().NotThrow();
        }

        [Fact]
        public async Task GetMenuAsync_WhenTheRepositoryThrowsAnException_ShouldThrowProperException()
        {
            var exceptionToThrow = new ArgumentException();

            var menuRepositoryMock = new Mock<IUnitOfWork<IBoltDbContext>>();
            menuRepositoryMock.Setup(x => x.GetRepository<IProductsRepository>())
                .Callback(() => throw exceptionToThrow);

            var service = new MenuService(menuRepositoryMock.Object);

            service
                .Awaiting(async sut => await sut.GetMenuAsync())
                .Should()
                .ThrowExactly<GetMenuAsyncException>()
                .WithMessage("Failed to get the menu, please try again.")
                .Where(hr => hr.HResult == 0x0000D001)
                .WithInnerException<Exception>();
        }


        [Fact]
        public async Task GetMenuAsync_WhenGetMenuAsyncThrowsAnException_ShouldThrowProperException()
        {
            var exceptionToThrow = new ArgumentException();

            var menuRepositoryMock = new Mock<IUnitOfWork<IBoltDbContext>>();
            var repositoryMock = new Mock<IMenuRepository>();
            repositoryMock.Setup(x => x.GetMenuAsync()).Callback(() => throw exceptionToThrow);
            var service = new MenuService(menuRepositoryMock.Object);

            service
                .Awaiting(async sut => await sut.GetMenuAsync())
                .Should()
                .ThrowExactly<GetMenuAsyncException>()
                .WithMessage("Failed to get the menu, please try again.")
                .Where(hr => hr.HResult == 0x0000D001)
                .WithInnerException<Exception>();
        }
        #endregion
    }
}
