namespace Bolt.UnitTests.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Moq;
    using Xunit;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;

    using DTOs.Users;
    using DTOs.Orders;
    using Bolt.Web.Controllers;
    using Bolt.Services.Contracts;
    using Bolt.Web.ViewModels.UserSettings;

    public class UserSettingsControllerTests
    {
        [Fact]
        public async Task Index_ValidUser_ShouldReturnUserSettingsViewModel()
        {
            var orders = new List<GetOrderDTO>
            {
                new GetOrderDTO
                {
                    Id = 1,
                    CreatedOn = DateTime.Now,
                    TotalPrice = 5.0
                }
            };
            var userDTO = new UserDTO
            {
                FirstName = "Test Firstname",
                LastName = "Test LastName",
                Address = "Test Address"
            };

            var expectedResult = new UserSettingsViewModel(userDTO, orders);

            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock
                .Setup(s => s.GetUserByUsernameAsync("Test"))
                .ReturnsAsync(userDTO);
            IUsersService usersServiceObject = usersServiceMock.Object;

            var ordersServiceMock = new Mock<IOrdersService>();
            ordersServiceMock
                .Setup(s => s.GetOrdersForUsername(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(orders);
            IOrdersService ordersServiceObject = ordersServiceMock.Object;

            var controller = new UserSettingsController(usersServiceObject, ordersServiceObject)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, "Test"),
                        }))
                    }
                }
            };

            IActionResult actualResult = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(actualResult);
            var model = Assert.IsAssignableFrom<UserSettingsViewModel>(viewResult.ViewData.Model);

            expectedResult.Should().BeEquivalentTo(model);
        }

        [Fact]
        public async Task Edit_PassValidModel_ShouldEditUser()
        {
            IUsersService usersServiceObject = new Mock<IUsersService>().Object;

            var controller = new UserSettingsController(usersServiceObject, null)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, "Test"),
                        }))
                    }
                }
            };

            var userDTO = new UserDTO
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName",
                Address = "Test Address"
            };

            await controller.Edit(userDTO);

            Mock.Get(usersServiceObject).Verify(v => v.EditUserAsync("Test", userDTO), Times.Once);
        }
    }
}
