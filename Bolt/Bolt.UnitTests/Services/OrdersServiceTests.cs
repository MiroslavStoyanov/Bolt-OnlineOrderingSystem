using Bolt.Data.Contexts.Bolt.Interfaces;
using Bolt.Data.Contexts.Bolt.Interfaces.Repositories;

namespace Bolt.UnitTests.Services
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Moq;
    using Xunit;
    using FluentAssertions;

    using Models;
    using DTOs.Orders;
    using DTOs.Products;
    using Core.Data.Repositories;
    using Bolt.Services.Implementations;

    public class OrdersServiceTests
    {
        #region ReOrder

        [Fact]
        public async Task ReOrder_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = this.GetMockedUnitOfWork().Object;

            const int orderId = 1;

            var service = new OrdersService(unitOfWorkMock);

            Action action = async () => await service.ReOrder(orderId);

            action.Should().NotThrow();
        }

        [Fact]
        public async Task ReOrder_WhenGetRepositoryThrowsAnException_ShouldThrowAnException()
        {
            var exceptionToThrow = new ArgumentException();
            var unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>();
            unitOfWorkMock.Setup(x => x.GetRepository<IOrdersRepository>()).Callback(() => throw exceptionToThrow);

            var service = new OrdersService(unitOfWorkMock.Object);

            service
                .Awaiting(async sut => await sut.ReOrder(2))
                .Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage("Failed to re-order, please try again.")
                .WithInnerException<Exception>();
        }

        [Fact]
        public async Task ReOrder_WhenGetOrderThrowsAnException_ShouldThrowAnException()
        {
            var exceptionToThrow = new ArgumentException();
            var unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>();
            var repositoryMock = new Mock<IOrdersRepository>();
            repositoryMock.Setup(x => x.GetOrder(It.IsAny<int>())).Callback(() => throw exceptionToThrow);

            var service = new OrdersService(unitOfWorkMock.Object);

            service
                .Awaiting(async sut => await sut.ReOrder(2))
                .Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage("Failed to re-order, please try again.")
                .WithInnerException<Exception>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("SomethingReallyLongSoItWouldNotFit")]
        public async Task ReOrder_WhenProductNameIsNull_ShouldThrowAnException(string productName)
        {
            var unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>();

            var productLine = new OrderLine
            {
                ProductName = productName
            };

            var service = new OrdersService(unitOfWorkMock.Object);

            service
                .Awaiting(async sut => await sut.ReOrder(2))
                .Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage("Failed to re-order, please try again.")
                .WithInnerException<Exception>();
        }
        #endregion

        #region GetOrderStatusAsync

        [Fact]
        public async Task GetOrderStatusAsync_WhenGetRepositoryThrowsAnException_ShouldThrowAnException()
        {
            var exceptionToThrow = new ArgumentException();
            var unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>();
            unitOfWorkMock.Setup(x => x.GetRepository<IOrdersRepository>()).Callback(() => throw exceptionToThrow);

            var service = new OrdersService(unitOfWorkMock.Object);

            service
                .Awaiting(async sut => await sut.GetOrderStatusAsync(1))
                .Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage("Failed to get the order status, please try again.")
                .WithInnerException<Exception>();
        }
        
        [Fact]
        public async Task GetOrderStatusAsync_WhenGetOrderStatusAsyncThrowsAnException_ShouldThrowAnException()
        {
            var exceptionToThrow = new ArgumentException();
            var unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>();
            var ordersRepositoryMock = new Mock<IOrdersRepository>();
            ordersRepositoryMock.Setup(x => x.GetOrderStatusAsync(It.IsAny<int>()))
                .Callback(() => throw exceptionToThrow);
            var service = new OrdersService(unitOfWorkMock.Object);

            service
                .Awaiting(async sut => await sut.GetOrderStatusAsync(1))
                .Should()
                .ThrowExactly<ArgumentException>()
                .WithInnerException<Exception>();
        }

        [Fact]
        public async Task GetOrderStatusAsync_GivenValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = this.GetMockedUnitOfWork().Object;

            var service = new OrdersService(unitOfWorkMock);

            Action result = async () => await service.GetOrderStatusAsync(1);

            result.Should().NotThrow();
        }
        #endregion
     
        [Fact]
        public async Task AddOrderAsync_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = this.GetMockedUnitOfWork().Object;

            var createOrderDto = new CreateOrderDTO
            {
                CreatedOn = DateTime.Now,
                Products = new List<ProductShoppingCartCache>
                    { new ProductShoppingCartCache { ProductName = "Cappucino", Quantity = 2 } },
            };

            var service = new OrdersService(unitOfWorkMock);

            Action action = async () => await service.AddOrderAsync(createOrderDto);

            action.Should().NotThrow();
        }

        [Fact]
        public async Task GetOrdersForUser_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = this.GetMockedUnitOfWork().Object;

            const string userId = "UserId";
            const int numberOfOrdersToTake = 3;

            var service = new OrdersService(unitOfWorkMock);

            Action result = async () => await service.GetOrdersForUser(userId, numberOfOrdersToTake);

            result.Should().NotThrow();
        }

        private Mock<IUnitOfWork<IBoltDbContext>> GetMockedUnitOfWork()
        {
            var unitOfWorkMocked = new Mock<IUnitOfWork<IBoltDbContext>>();
            return unitOfWorkMocked;
        }
    }
}
