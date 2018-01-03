namespace Bolt.UnitTests.Services
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Moq;
    using Xunit;
    using FluentAssertions;

    using DTOs.Orders;
    using DTOs.Products;
    using Core.Data.Repositories;
    using Data.Contexts.Bolt.Core;
    using Bolt.Services.Implementations;

    public class OrdersServiceTests
    {
        [Fact]
        public async Task GetOrderStatusAsync_GivenValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = this.GetMockedUnitOfWork().Object;

            var service = new OrdersService(unitOfWorkMock);

            Action result = async () => await service.GetOrderStatusAsync(1);

            result.Should().NotThrow();
        }

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
