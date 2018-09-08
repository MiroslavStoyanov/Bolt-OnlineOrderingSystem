namespace Bolt.Web.Controllers
{
    using System.Threading.Tasks;
    using Bolt.DTOs.Products;
    using Bolt.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ProductDetailsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductDetailsController(IProductsService productsService)
        {
            this._productsService = productsService;
        }

        public async Task<IActionResult> Index(int productId)
        {
            ProductDetailsDTO product = await this._productsService.GetProductDetailsAsync(productId);
            return this.View(product);
        }
    }
}