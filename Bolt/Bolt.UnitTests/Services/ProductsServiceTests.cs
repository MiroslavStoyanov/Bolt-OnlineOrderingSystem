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
    using Data.Contexts.Bolt.Core.Repositories;
    using Bolt.Services.ExceptionHandling.Exceptions;

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

        [Theory]
        [InlineData(-1)]
        [InlineData(null)]
        public async Task GetProductDetailsAsync_GivenANullProductId_ShouldThrowAnException(int productId)
        {
            var unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>();

            var service = new ProductsService(unitOfWorkMock.Object);

            service
                .Awaiting(async sut => await sut.GetProductDetailsAsync(productId))
                .Should()
                .ThrowExactly<GetProductDetailsException>()
                .WithMessage("Failed to get the product details, please try again.")
                .Where(hr => hr.HResult == 0x0000D007)
                .WithInnerException<Exception>();
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
        public async Task GetAllProductsAsync_WhenAnUnexpectedExceptionIsThrown_ShouldThrowAnException()
        {
            var exceptionToThrow = new ArgumentException();
            var unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>();
            unitOfWorkMock.Setup(x => x.GetRepository<IProductsRepository>()).Callback(() => throw exceptionToThrow);

            var service = new ProductsService(unitOfWorkMock.Object);

            service
                .Awaiting(async sut => await sut.GetAllProductsAsync())
                .Should()
                .ThrowExactly<GetAllProductsAsyncException>()
                .WithMessage("Failed to get all products. Please try again.")
                .Where(hr => hr.HResult == 0x0000D009)
                .WithInnerException<Exception>();
        }

        [Fact]
        public async Task GetProductsByIDsAsync_WhenGetRepositoryThrowsAnException_ShouldThrowAnException()
        {
            var exceptionToThrow = new ArgumentException();
            var unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>();
            unitOfWorkMock.Setup(x => x.GetRepository<IProductsRepository>()).Callback(() => throw exceptionToThrow);
            IEnumerable<int> productIds = new List<int>();

            var service = new ProductsService(unitOfWorkMock.Object);

            service
                .Awaiting(async sut => await sut.GetProductsByIDsAsync(productIds))
                .Should()
                .ThrowExactly<GetProductsByIDsAsyncException>()
                .WithMessage("Failed to get the product Ids. Please try again.")
                .Where(hr => hr.HResult == 0x0000D010)
                .WithInnerException<Exception>();
        }

        [Fact]
        public async Task GetProductsByIDsAsync_WhenGetProductsByIDsAsyncThrowsAnException_ShouldThrowAnException()
        {
            var exceptionToThrow = new ArgumentException();
            var productRepositoryMock = new Mock<IProductsRepository>();
            productRepositoryMock.Setup(x => x.GetProductsByIDsAsync(It.IsAny<IEnumerable<int>>()))
                .Callback(() => throw exceptionToThrow);
            var unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>();
            IEnumerable<int> productIds = new List<int>();

            var service = new ProductsService(unitOfWorkMock.Object);

            service
                .Awaiting(async sut => await sut.GetProductsByIDsAsync(productIds))
                .Should()
                .ThrowExactly<GetProductsByIDsAsyncException>()
                .WithMessage("Failed to get the product Ids. Please try again.")
                .Where(hr => hr.HResult == 0x0000D010)
                .WithInnerException<Exception>();
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
