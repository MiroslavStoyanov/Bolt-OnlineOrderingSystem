using Bolt.Services.Interfaces;

namespace Bolt.UnitTests.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Moq;
    using Xunit;
    using Newtonsoft.Json;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using DTOs.Products;
    using Bolt.Web.Services;
    using Bolt.Web.Controllers;
    using Bolt.Web.ViewModels.Cart;

    public class CartControllerTests
    {
        [Fact]
        public async Task Index_WhenEmptyCart_ShouldReturnViewWithEmptyList()
        {
            var cartController = new CartController(new CookieCachingService(new Mock<IMemoryCache>().Object), null, null, null);

            IActionResult actualResult = await cartController.Index();

            var viewResult = Assert.IsType<ViewResult>(actualResult);
            var model = Assert.IsAssignableFrom<List<ProductViewModel>>(viewResult.ViewData.Model);

            Assert.Empty(model);
        }

        [Fact]
        public async Task Index_WhenNotEmptyCart_ShouldReturnViewWithNotEmptyList()
        {
            var expectedResult = new ProductViewModel
            {
                Description = "Test Description",
                Quantity = 3,
                Id = 1,
                Name = "Test",
                Price = 2.5
            };

            var cookieCachingServiceMock = new Mock<ICookieCachingService>();
            var cachedProducts = new List<ProductShoppingCartCache>
            {
                new ProductShoppingCartCache
                {
                    Id = 1,
                    ProductName = "Test",
                    Quantity = 3
                }
            };
            cookieCachingServiceMock.Setup(s => s.Get(It.IsAny<string>()))
                .Returns(JsonConvert.SerializeObject(cachedProducts));
            ICookieCachingService cookieCachingServiceObject = cookieCachingServiceMock.Object;

            var productsServiceMock = new Mock<IProductsService>();
            productsServiceMock
                .Setup(s => s.GetProductsByIDsAsync(It.IsAny<IEnumerable<int>>()))
                    .ReturnsAsync(new List<ProductDTO>
                    {
                    new ProductDTO
                    {
                        Id = 1,
                        Name = "Test",
                        Description = "Test Description",
                        Price = 2.5
                    }
    });
            IProductsService productsServiceObject = productsServiceMock.Object;

            var cartController = new CartController(cookieCachingServiceObject, productsServiceObject, null, null);

            IActionResult actualResult = await cartController.Index();

            var viewResult = Assert.IsType<ViewResult>(actualResult);
            var model = Assert.IsAssignableFrom<List<ProductViewModel>>(viewResult.ViewData.Model);

            Assert.Single(model);
            expectedResult.Should().BeEquivalentTo(model.FirstOrDefault());
        }
    }
}