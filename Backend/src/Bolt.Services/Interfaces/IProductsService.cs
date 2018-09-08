using System.Collections.Generic;
using System.Threading.Tasks;
using Bolt.DTOs.Products;

namespace Bolt.Services.Interfaces
{
    public interface IProductsService
    {
        Task<ProductDetailsDTO> GetProductDetailsAsync(int productId);

        Task<List<ProductDTO>> GetAllProductsAsync();

        Task<List<ProductDTO>> GetProductsByIDsAsync(IEnumerable<int> productIds);

        Task AddProductAsync(ProductDTO model);

        Task UpdateProductAsync(int productId, ProductDTO model);

        Task DeleteProductAsync(int productId);
    }
}