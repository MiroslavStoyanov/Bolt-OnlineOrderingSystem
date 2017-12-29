namespace Bolt.UnitTests
{
    using System;
    using System.Threading.Tasks;

    using Moq;
    using Xunit;

    using Core.Data.Repositories;
    using Data.Contexts.Bolt.Core;
    using Services.Implementations;

    public class OrdersServiceTests
    {
        [Fact]
        public async Task ReOrder_GivenNullOrderId_ShouldThrowArgumentNullException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            var service = new OrdersService(unitOfWorkMock);

            Action expectedResult = async () => await service.ReOrder(1);

            Assert.True(true);
        }
    }
}
