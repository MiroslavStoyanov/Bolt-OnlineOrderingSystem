namespace Bolt.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Bolt.DTOs.Users;
    using Bolt.Services.Interfaces;
    using Bolt.Web.Infrastructure.Statics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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

            return this.View(users);
        }
    }
}