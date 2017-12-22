﻿namespace Bolt.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Services;
    using Bolt.DTOs.Menu;
    using Bolt.Services.Contracts;
    using Bolt.Data.Contexts.Bolt.Core.Repositories;
    using Bolt.Core.Data.Repositories;
    using Bolt.Data.Contexts.Bolt.Core;
    using Bolt.DTOs.Products;

    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly CookieCachingService _cacheService;
        private readonly IUnitOfWork<IBoltDbContext> _unitOfWork;

        public MenuController(
            IMenuService menuService,
            CookieCachingService cacheService,
            IUnitOfWork<IBoltDbContext> unitOfWork)
        {
            this._menuService = menuService;
            this._cacheService = cacheService;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            GetMenuDTO menu = await this._menuService.GetMenuAsync();

            return View(menu);
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
            return this.RedirectToAction("Index", "ProductDetailsController", new { productId = productId });
        }

    }
}