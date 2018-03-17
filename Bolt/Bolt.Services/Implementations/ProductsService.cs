namespace Bolt.Services.Implementations
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models;
    using DTOs.Products;
    using Core.Validation;
    using Core.Data.Repositories;
    using Bolt.Data.Contexts.Bolt.Interfaces;
    using Bolt.Data.Contexts.Bolt.Interfaces.Repositories;
    using Bolt.Services.ExceptionHandling;
    using Bolt.Services.Interfaces;

    public class ProductsService : IProductsService
    {
        private readonly IUnitOfWork<IBoltDbContext> _unitOfWork;

        public ProductsService(IUnitOfWork<IBoltDbContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ProductDetailsDTO> GetProductDetailsAsync(int productId)
        {
            try
            {
                IProductsRepository productsRepository = this._unitOfWork.GetRepository<IProductsRepository>();

                ProductDetailsDTO product = await productsRepository.GetProductDetailsAsync(productId);

                return product;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.GetProductDetailsMessage, ex);
            }
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            try
            {
                IProductsRepository productsRepository = this._unitOfWork.GetRepository<IProductsRepository>();

                List<ProductDTO> products = await productsRepository.GetAllProductsAsync();

                return products;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.GetAllProductsMessage, ex);
            }
        }

        public async Task<List<ProductDTO>> GetProductsByIDsAsync(IEnumerable<int> productIds)
        {
            try
            {
                IProductsRepository productsRepository = this._unitOfWork.GetRepository<IProductsRepository>();

                List<ProductDTO> products = await productsRepository.GetProductsByIDsAsync(productIds);

                return products;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.GetProductsByIDsMessage, ex);
            }
        }

        public async Task AddProductAsync(ProductDTO model)
        {
            Require.ThatObjectIsNotNull(model, typeof(ArgumentNullException), ExceptionMessages.AddProductModelNullMessage);

            try
            {
                await this._unitOfWork.DbContext.Products.AddAsync(new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price
                });

                await this._unitOfWork.DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.AddProductMessage, ex);
            }
        }

        public async Task UpdateProductAsync(int productId, ProductDTO model)
        {
            Require.ThatIntIsNotNull(productId, typeof(ArgumentNullException), ExceptionMessages.UpdateProductNullProductIdMessage);
            Require.ThatObjectIsNotNull(model, typeof(ArgumentNullException), ExceptionMessages.UpdateProductNullModelMessage);

            try
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
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.UpdateProductMessage, ex);
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            Require.ThatIntIsNotNull(productId, typeof(ArgumentNullException), ExceptionMessages.DeleteProductNullIdMessage);

            try
            {
                this._unitOfWork.DbContext.Products.Remove(new Product
                {
                    Id = productId
                });

                await this._unitOfWork.DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.DeleteProductMessage, ex);
            }
        }
    }
}