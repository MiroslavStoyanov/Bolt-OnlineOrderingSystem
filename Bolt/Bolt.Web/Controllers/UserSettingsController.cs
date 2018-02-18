namespace Bolt.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Bolt.Services.Interfaces;
    using DTOs.Users;
    using DTOs.Orders;
    using ViewModels.UserSettings;

    [Authorize]
    public class UserSettingsController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IOrdersService _ordersService;

        public UserSettingsController(IUsersService usersService, IOrdersService ordersService)
        {
            this._usersService = usersService;
            this._ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            const int numberOfOrdersToTake = 10;
            string username = this.User.Identity.Name;

            UserDTO user = await this._usersService.GetUserByUsernameAsync(username);
            List<GetOrderDTO> orders = await this._ordersService.GetOrdersForUsername(username, numberOfOrdersToTake);

            var userSettingsViewModel = new UserSettingsViewModel(user, orders);
            return View(userSettingsViewModel);
        }

        public async Task<IActionResult> Edit(UserDTO model)
        {
            string username = this.User.Identity.Name;
            await this._usersService.EditUserAsync(username, model);

            return RedirectToAction("Index");
        }
    }
}