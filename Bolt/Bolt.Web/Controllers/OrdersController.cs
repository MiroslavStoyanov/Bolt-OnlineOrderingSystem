using Bolt.Services.Interfaces;

namespace Bolt.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this._ordersService = ordersService;
        }

        public async Task<IActionResult> ReOrder(int orderId)
        {
            int newOrderId = await this._ordersService.ReOrder(orderId);

            return RedirectToAction("Index", "OrderTracker", new { orderId = newOrderId });
        }
    }
}