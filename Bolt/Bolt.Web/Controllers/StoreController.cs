﻿namespace Bolt.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}