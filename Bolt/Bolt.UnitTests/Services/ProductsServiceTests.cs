namespace Bolt.UnitTests.Services
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Moq;
    using Xunit;
    using FluentAssertions;

    using Models;
    using DTOs.Products;
    using Core.Data.Repositories;
    using Data.Contexts.Bolt.Core;
    using Bolt.Services.Implementations;
    using Data.Contexts.Bolt.Core.Repositories;
    using Bolt.Services.ExceptionHandling.Exceptions;

    public class ProductsServiceTests
    {
        #region GetProductDetailsAsync

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
        #endregion

        #region GetAllProductsAsync

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
        #endregion

        #region GetProductsByIDsAsync

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
        #endregion

        #region AddProductAsync

        [Fact]
        public async Task AddProductAsync_GivenNullProductDTO_ShouldThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            var service = new ProductsService(unitOfWorkMock);

            service
                .Awaiting(async sut => await sut.AddProductAsync(null))
                .Should()
                .ThrowExactly<AddProductAsyncException>()
                .WithMessage("The model cannot be null or empty.")
                .Where(hr => hr.HResult == 0x0000D012);
        }

        [Theory]
        [InlineData("", "Some random test description")]
        [InlineData(null, "Some random test description")]
        [InlineData("Coffee", "")]
        [InlineData("Coffee", null)]
        public async Task AddProductAsync_GivenNullNameProductDTO_ShouldThrowAnException(string name, string description)
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            var productDto = new ProductDTO
            {
                Name = name,
                Description = description
            };

            var service = new ProductsService(unitOfWorkMock);

            service
                .Awaiting(async sut => await sut.AddProductAsync(productDto))
                .Should()
                .ThrowExactly<AddProductAsyncException>()
                .WithMessage("Failed to add the product to the basket. Please try again.")
                .Where(hr => hr.HResult == 0x0000D011)
                .WithInnerException<Exception>();
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
        #endregion

        #region UpdateProductAsync

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

        [Theory]
        [InlineData("", "Some random description")]
        [InlineData(null, "Some random description")]
        [InlineData("Test", "")]
        [InlineData("Test", null)]
        public async Task UpdateProdcutAsync_GivenNullParameters_ShouldThrowAnException(string name, string description)
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            var productDto = new ProductDTO
            {
                Name = name,
                Description = description
            };

            var service = new ProductsService(unitOfWorkMock);

            service
                .Awaiting(async sut => await sut.UpdateProductAsync(2, productDto))
                .Should()
                .ThrowExactly<UpdateProductAsyncException>()
                .WithMessage("Failed to update the product. Please try again.")
                .Where(hr => hr.HResult == 0x0000D015)
                .WithInnerException<Exception>();
        }

        [Fact]
        public async Task UpdateProductAsync_WhenUpdateThrowsAnException_ShouldThrowAnException()
        {
            var exceptionToThrow = new ArgumentException();
            var unitofWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>();
            unitofWorkMock.Setup(x => x.DbContext.Products.Update(It.IsAny<Product>()))
                .Callback(() => throw exceptionToThrow);

            var service = new ProductsService(unitofWorkMock.Object);

            service
                .Awaiting(async sut => await sut.UpdateProductAsync(2, new ProductDTO()))
                .Should()
                .ThrowExactly<UpdateProductAsyncException>()
                .WithMessage("Failed to update the product. Please try again.")
                .Where(hr => hr.HResult == 0x0000D015)
                .WithInnerException<Exception>();
        }

        [Fact]
        public async Task UpdateProductAsync_GivenNullProductDTO_ShouldThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            var service = new ProductsService(unitOfWorkMock);

            service
                .Awaiting(async sut => await sut.UpdateProductAsync(2, null))
                .Should()
                .ThrowExactly<UpdateProductAsyncException>()
                .WithMessage("The model cannot be null or empty.")
                .Where(hr => hr.HResult == 0x0000D014);
        }
        #endregion

        #region DeleteProductAsync
        
        [Fact]
        public async Task DeleteProductAsync_WhenRemoveThrowsAnException_ShouldThrowAnException()
        {
            var exceptionToThrow = new ArgumentException();
            var unitofWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>();
            unitofWorkMock.Setup(x => x.DbContext.Products.Remove(It.IsAny<Product>()))
                .Callback(() => throw exceptionToThrow);

            var service = new ProductsService(unitofWorkMock.Object);

            service
                .Awaiting(async sut => await sut.DeleteProductAsync(2))
                .Should()
                .ThrowExactly<DeleteProductAsyncException>()
                .WithMessage("Failed to delete the product. Please try again.")
                .Where(hr => hr.HResult == 0x0000D016)
                .WithInnerException<Exception>();
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
        #endregion
    }
}
