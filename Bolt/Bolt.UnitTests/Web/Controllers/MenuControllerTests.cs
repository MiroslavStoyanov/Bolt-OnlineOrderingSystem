using System.Threading.Tasks;
using Bolt.DTOs.Orders;
using Bolt.Services.Contracts;
using Bolt.Web.Controllers;
using Bolt.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;

namespace Bolt.UnitTests.Web.Controllers
{
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
