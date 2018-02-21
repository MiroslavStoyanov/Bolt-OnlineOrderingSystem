using System.Collections.Generic;
using System.Threading.Tasks;
using Bolt.Core.Data.Repositories;
using Bolt.DTOs.Products;
using Bolt.Models;

namespace Bolt.Data.Contexts.Bolt.Interfaces.Repositories
{
    public interface IProductsRepository : IEFRepository<Product>
    {
        Task<ProductDetailsDTO> GetProductDetailsAsync(int productId);

        Task<List<ProductDTO>> GetAllProductsAsync();

        Task<List<ProductDTO>> GetProductsByIDsAsync(IEnumerable<int> productIds);
    }
}
