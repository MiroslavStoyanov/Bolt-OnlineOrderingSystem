namespace Bolt.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            string apiUri = this.Url.RouteUrl("DefaultApi", new { controller = "admin", });
            this.ViewBag.ApiUrl = new Uri(this.Request.Path).AbsoluteUri.ToString();

            return View();
        }
    }
}