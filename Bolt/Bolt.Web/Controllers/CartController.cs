namespace Bolt.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Services;
    using Bolt.Models;
    using DTOs.Orders;
    using DTOs.Products;
    using ViewModels.Cart;
    using Bolt.Services.Contracts;

    [Authorize]
    public class CartController : Controller
    {
        private readonly CookieCachingService _cacheService;
        private readonly IProductsService _productService;
        private readonly IOrdersService _ordersService;
        private readonly IUsersService _usersService;

        public CartController(
            CookieCachingService service,
            IProductsService productService,
            IOrdersService ordersService,
            IUsersService usersService)
        {
            this._cacheService = service;
            this._productService = productService;
            this._ordersService = ordersService;
            this._usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            var products = new List<ProductViewModel>();

            string cachedProducts = this._cacheService.Get("products");

            if (string.IsNullOrEmpty(cachedProducts))
            {
                return this.View(products);
            }

            var deserializedProducts =
                JsonConvert.DeserializeObject<List<DTOs.Products.ProductShoppingCartCache>>(cachedProducts);

            IEnumerable<int> productIds = deserializedProducts.Select(a => a.Id);
            List<ProductDTO> productEntities = await this._productService.GetProductsByIDsAsync(productIds);

            foreach (ProductDTO productDTO in productEntities)
            {
                products.Add(new ProductViewModel
                {
                    Id = productDTO.Id,
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    Description = productDTO.Description,
                    Quantity = deserializedProducts.FirstOrDefault(p => p.Id == productDTO.Id)?.Quantity
                });
            }

            return this.View(products);
        }

        [HttpDelete]
        public bool RemoveItem(int? productId)
        {
            string cachedProducts = this._cacheService.Get("products");

            var deserializedProducts = JsonConvert.DeserializeObject<List<DTOs.Products.ProductShoppingCartCache>>(cachedProducts);

            deserializedProducts.RemoveAll(pr => pr.Id == productId);

            this._cacheService.Set("products", JsonConvert.SerializeObject(deserializedProducts), 30);

            return true;
        }

        [HttpPost]
        public void EditItemQuantity(int productId, int quantity)
        {
            string cachedProducts = this._cacheService.Get("products");

            var deserializedProducts = JsonConvert.DeserializeObject<List<DTOs.Products.ProductShoppingCartCache>>(cachedProducts);

            ProductShoppingCartCache product = deserializedProducts.FirstOrDefault(p => p.Id == productId);
            product.Quantity = quantity;

            this._cacheService.Set("products", JsonConvert.SerializeObject(deserializedProducts), 30);
        }

        public async Task<IActionResult> Order()
        {
            string cachedProducts = this._cacheService.Get("products");

            var deserializedProducts = JsonConvert.DeserializeObject<List<DTOs.Products.ProductShoppingCartCache>>(cachedProducts);

            string username = this.User.Identity.Name;
            string userId = await this._usersService.GetUserIdByUsernameAsync(username);

            var orderDTO = new CreateOrderDTO
            {
                CreatedOn = DateTime.Now,
                OrderStatus = OrderStatus.Accepted,
                UserId = userId,
                Products = deserializedProducts
            };

            int orderId = await this._ordersService.AddOrderAsync(orderDTO);

            this._cacheService.Remove("products");

            return this.RedirectToAction("Index", "OrderTracker", new { orderId });
        }
    }
}