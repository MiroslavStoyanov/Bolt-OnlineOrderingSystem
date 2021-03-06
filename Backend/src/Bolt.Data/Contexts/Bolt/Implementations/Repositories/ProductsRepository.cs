﻿namespace Bolt.Data.Contexts.Bolt.Implementations.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using global::Bolt.Core.Data.Repositories;
    using global::Bolt.Data.Contexts.Bolt.Interfaces;
    using global::Bolt.Data.Contexts.Bolt.Interfaces.Repositories;
    using global::Bolt.DTOs.Products;
    using global::Bolt.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProductsRepository : EFRepository<Product>, IProductsRepository
    {
        public ProductsRepository(IBoltDbContext context)
            : base(context)
        {
        }

        public async Task<ProductDetailsDTO> GetProductDetailsAsync(int productId)
        {
            ProductDetailsDTO product = await this.Where(p => p.Id == productId)
                .ProjectTo<ProductDetailsDTO>()
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            List<ProductDTO> products = await this
                .AsQueryable()
                .ProjectTo<ProductDTO>()
                .ToListAsync();

            return products;
        }

        public async Task<List<ProductDTO>> GetProductsByIDsAsync(IEnumerable<int> productIds)
        {
            List<ProductDTO> products = await this
                .Where(p => productIds.Contains(p.Id))
                .ProjectTo<ProductDTO>()
                .ToListAsync();

            return products;
        }
    }
}