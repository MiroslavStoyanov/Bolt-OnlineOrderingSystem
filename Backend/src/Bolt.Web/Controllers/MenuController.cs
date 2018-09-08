namespace Bolt.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Bolt.DTOs.Orders;
    using Bolt.DTOs.Products;
    using Bolt.Services.Interfaces;
    using Bolt.Web.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly ICookieCachingService _cacheService;

        public MenuController(
            IMenuService menuService,
            ICookieCachingService cacheService)
        {
            this._menuService = menuService;
            this._cacheService = cacheService;
        }

        public async Task<IActionResult> Index()
        {
            GetMenuDTO menu = await this._menuService.GetMenuAsync();

            return this.View(menu);
        }

        [HttpPost]
        public void AddItemToCart(int productId, string productName, int quantity)
        {
            string productsCache = this._cacheService.Get("products");

            if (productsCache == null)
            {
                var products = new List<ProductShoppingCartCache>
                {
                    new ProductShoppingCartCache
                    {
                        Id = productId,
                        Quantity = quantity,
                        ProductName = productName
                    }
                };

                this._cacheService.Set("products", JsonConvert.SerializeObject(products), 30);
            }
            else
            {
                var products = JsonConvert.DeserializeObject<List<ProductShoppingCartCache>>(productsCache);

                if (products.Any(p => p.Id == productId))
                {
                    products.First(p => p.Id == productId).Quantity += quantity;
                }
                else
                {
                    var productsInShoppingCart = new ProductShoppingCartCache
                    {
                        Id = productId,
                        Quantity = quantity,
                        ProductName = productName
                    };
                    products.Add(productsInShoppingCart);
                }

                this._cacheService.Set("products", JsonConvert.SerializeObject(products), 30);
            }
        }

        [HttpGet]
        public IActionResult OpenProductDetailsAsync(int productId)
        {
            return this.RedirectToAction("Index", "ProductDetailsController", new {productId});
        }
    }
}