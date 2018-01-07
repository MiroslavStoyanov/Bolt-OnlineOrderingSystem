namespace Bolt.UnitTests.Web.Controllers
{
    using System.Threading.Tasks;

    using Moq;
    using Xunit;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using DTOs.Orders;
    using Bolt.Web.Services;
    using Bolt.Web.Controllers;
    using Bolt.Services.Contracts;

    public class MenuControllerTests
    {
        [Fact]
        public async Task Index_GivenAValidScenario_ShouldReturnAMenuView()
        {
            var menuServiceMock = new Mock<IMenuService>();
            menuServiceMock.Setup(x => x.GetMenuAsync()).ReturnsAsync(It.IsAny<GetMenuDTO>());
            var controller = new MenuController(menuServiceMock.Object, new CookieCachingService(new MemoryCache(new MemoryCacheOptions())));

            Task<IActionResult> result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}
