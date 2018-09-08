namespace Bolt.Data.Contexts.Bolt.Interfaces.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::Bolt.Core.Data.Repositories;
    using global::Bolt.DTOs.Products;
    using global::Bolt.Models;

    public interface IProductsRepository : IEFRepository<Product>
    {
        Task<ProductDetailsDTO> GetProductDetailsAsync(int productId);

        Task<List<ProductDTO>> GetAllProductsAsync();

        Task<List<ProductDTO>> GetProductsByIDsAsync(IEnumerable<int> productIds);
    }
}