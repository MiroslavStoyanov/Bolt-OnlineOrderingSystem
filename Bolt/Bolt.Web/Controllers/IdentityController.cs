namespace Bolt.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class IdentityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}