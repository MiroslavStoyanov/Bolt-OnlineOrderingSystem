namespace Bolt.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using DTOs.Products;
    using Bolt.Services.Contracts;

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
            return View(product);
        }
    }
}