namespace Bolt.Web.Controllers
{
    using System.Threading.Tasks;
    using Bolt.Models;
    using Bolt.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

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
            return this.View(orderStatus);
        }
    }
}