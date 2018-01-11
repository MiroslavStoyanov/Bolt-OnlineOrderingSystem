namespace Bolt.Services.Implementations
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models;
    using Contracts;
    using DTOs.Products;
    using Core.Data.Repositories;
    using Data.Contexts.Bolt.Core;
    using Data.Contexts.Bolt.Core.Repositories;

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
                throw new ArgumentException("Failed to get the product details. Please try again.", ex);
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
                throw new ArgumentException("Getting the products has failed. Please try again.", ex);
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
                throw new ArgumentException("Getting the products by Id has failed. Please try again.", ex);
            }
        }

        public async Task AddProductAsync(ProductDTO model)
        {
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
                throw new ArgumentException("Adding the product has failed. Please try again.", ex);
            }
        }

        public async Task UpdateProductAsync(int productId, ProductDTO model)
        {
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
                throw new ArgumentException("Updating the product has failed. Please try again.", ex);
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
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
                throw new ArgumentException("Deleting the product has failed. Please try again.", ex);
            }
        }
    }
}