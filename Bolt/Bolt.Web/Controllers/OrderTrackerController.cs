using Bolt.Services.Interfaces;

namespace Bolt.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Bolt.Models;

    public class OrderTrackerController : Controller
    {
        private readonly IOrdersService _ordersService;

        public OrderTrackerController(IOrdersService ordersService)
        {
            this._ordersService = ordersService;
        }

        public async Task<IActionResult> Index(int orderId)
        {
            OrderStatus orderStatus = await this._ordersService.GetOrderStatusAsync(orderId);
            return View(orderStatus);
        }
    }
}