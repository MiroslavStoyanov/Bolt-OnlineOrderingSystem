namespace Bolt.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DTOs.Users;
    using Bolt.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Infrastructure.Statics;

    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class IdentityController : Controller
    {
        private readonly IUsersService _usersService;

        public IdentityController(IUsersService usersService)
        {
            this._usersService = usersService;
        }

        public async Task<IActionResult> All()
        {
            List<ListUserViewModel> users = await this._usersService.GetAllUsersAsync();

            return View(users);
        }

    }
}