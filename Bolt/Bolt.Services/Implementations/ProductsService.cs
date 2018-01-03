using Bolt.Core.Data.Repositories;
using Bolt.Data.Contexts.Bolt.Core;
using Bolt.Data.Contexts.Bolt.Core.Repositories;
using Bolt.Models;

namespace Bolt.Services.Implementations
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Contracts;
    using DTOs.Products;

    public class ProductsService : IProductsService
    {
        private readonly IUnitOfWork<IBoltDbContext> _unitOfWork;

        public ProductsService(IUnitOfWork<IBoltDbContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ProductDetailsDTO> GetProductDetailsAsync(int productId)
        {
            IProductsRepository productsRepository = this._unitOfWork.GetRepository<IProductsRepository>();

            ProductDetailsDTO product = await productsRepository.GetProductDetailsAsync(productId);

            return product;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            IProductsRepository productsRepository = this._unitOfWork.GetRepository<IProductsRepository>();

            List<ProductDTO> products = await productsRepository.GetAllProductsAsync();

            return products;
        }

        public async Task<List<ProductDTO>> GetProductsByIDsAsync(IEnumerable<int> productIds)
        {
            IProductsRepository productsRepository = this._unitOfWork.GetRepository<IProductsRepository>();

            List<ProductDTO> products = await productsRepository.GetProductsByIDsAsync(productIds);

            return products;
        }

        public async Task AddProductAsync(ProductDTO model)
        {
            await this._unitOfWork.DbContext.Products.AddAsync(new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            });

            await this._unitOfWork.DbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int productId, ProductDTO model)
        {
            this._unitOfWork.DbContext.Products.Update(new Product
            {
                Id = productId,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            });

            await this._unitOfWork.DbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            this._unitOfWork.DbContext.Products.Remove(new Product
            {
                Id = productId
            });

            await this._unitOfWork.DbContext.SaveChangesAsync();
        }
    }
}