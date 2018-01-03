namespace Bolt.UnitTests.Services
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Moq;
    using Xunit;
    using FluentAssertions;

    using DTOs.Products;
    using Core.Data.Repositories;
    using Data.Contexts.Bolt.Core;
    using Bolt.Services.Implementations;

    public class ProductsServiceTests
    {
        [Fact]
        public async Task GetProductDetailsAsync_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            const int productId = 2;

            var service = new ProductsService(unitOfWorkMock);

            Action result = async () => await service.GetProductDetailsAsync(productId);

            result.Should().NotThrow();
        }

        [Fact]
        public async Task GetAllProductsAsync_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            var service = new ProductsService(unitOfWorkMock);

            Action result = async () => await service.GetAllProductsAsync();

            result.Should().NotThrow();
        }

        [Fact]
        public async Task GetProductsByIDsAsync_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            IEnumerable<int> productIds = new List<int>();

            var service = new ProductsService(unitOfWorkMock);

            Action result = async () => await service.GetProductsByIDsAsync(productIds);

            result.Should().NotThrow();
        }

        [Fact]
        public async Task AddProductAsync_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            var productDto = new ProductDTO
            {
                Name = "Cappucino",
                Description = "This is a test description",
                Price = 2.5
            };

            var service = new ProductsService(unitOfWorkMock);

            Action result = async () => await service.AddProductAsync(productDto);

            result.Should().NotThrow();
        }

        [Fact]
        public async Task UpdateProductAsync_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            const int productId = 2;

            var productDto = new ProductDTO
            {
                Name = "Cappucino",
                Description = "This is a test description",
                Price = 2.5
            };

            var service = new ProductsService(unitOfWorkMock);

            Action result = async () => await service.UpdateProductAsync(productId, productDto);

            result.Should().NotThrow();
        }

        [Fact]
        public async Task DeleteProductAsync_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            const int productId = 2;
     
            var service = new ProductsService(unitOfWorkMock);

            Action result = async () => await service.DeleteProductAsync(productId);

            result.Should().NotThrow();
        }
    }
}
