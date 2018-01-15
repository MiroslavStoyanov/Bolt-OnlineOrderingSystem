namespace Bolt.Services.Implementations
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models;
    using Contracts;
    using DTOs.Products;
    using Core.Validation;
    using ExceptionHandling;
    using Core.Data.Repositories;
    using Data.Contexts.Bolt.Core;
    using ExceptionHandling.Exceptions;
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
            Require.ThatIntIsNotNull(productId, typeof(GetProductDetailsException), ServicesErrorCodes.GetProductDetails);

            try
            {
                IProductsRepository productsRepository = this._unitOfWork.GetRepository<IProductsRepository>();

                ProductDetailsDTO product = await productsRepository.GetProductDetailsAsync(productId);

                return product;
            }
            catch (Exception ex)
            {
                throw new GetProductDetailsException(ServicesErrorCodes.GetProductDetails, ex);
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
                throw new GetAllProductsAsyncException(ServicesErrorCodes.GetAllProducts, ex);
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
                throw new GetProductsByIDsAsyncException(ServicesErrorCodes.GetProductsByIDs, ex);
            }
        }

        public async Task AddProductAsync(ProductDTO model)
        {
            Require.ThatObjectIsNotNull(model, typeof(AddProductAsyncException), ServicesErrorCodes.AddProductModelNull);

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
                throw new AddProductAsyncException(ServicesErrorCodes.AddProduct, ex);
            }
        }

        public async Task UpdateProductAsync(int productId, ProductDTO model)
        {
            Require.ThatIntIsNotNull(productId, typeof(UpdateProductAsyncException), ServicesErrorCodes.UpdateProductNullProductId);
            Require.ThatObjectIsNotNull(model, typeof(UpdateProductAsyncException), ServicesErrorCodes.UpdateProductNullModel);

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
                throw new UpdateProductAsyncException(ServicesErrorCodes.UpdateProduct, ex);
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            Require.ThatIntIsNotNull(productId, typeof(DeleteProductAsyncException), ServicesErrorCodes.DeleteProductNullId);

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
                throw new DeleteProductAsyncException(ServicesErrorCodes.DeleteProduct, ex);
            }
        }
    }
}