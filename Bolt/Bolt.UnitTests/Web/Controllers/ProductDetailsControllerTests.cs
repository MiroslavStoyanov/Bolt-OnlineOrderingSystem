namespace Bolt.UnitTests.Web.Controllers
{
    using System.Threading.Tasks;

    using Moq;
    using Xunit;
    using Microsoft.AspNetCore.Mvc;

    using DTOs.Products;
    using Bolt.Services.Contracts;
    using Bolt.Web.Controllers;

    public class ProductDetailsControllerTests
    {
        [Fact]
        public async Task Index_GivenAValidProductId_ShouldReturnProperView()
        {
            //Arrange
            const int productId = 5;
            var productServiceMock = new Mock<IProductsService>();
            productServiceMock.Setup(x => x.GetProductDetailsAsync(productId))
                .ReturnsAsync(this.GetProductDetails());
            var controller = new ProductDetailsController(productServiceMock.Object);

            //Act
            IActionResult result = await controller.Index(productId);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        private ProductDetailsDTO GetProductDetails()
        {
            var productDetailsDto = new ProductDetailsDTO
            {
                Price = 5.35,
                Description = "Some short description",
                Name = "Cappucino"
            };

            return productDetailsDto;
        }
    }
}
