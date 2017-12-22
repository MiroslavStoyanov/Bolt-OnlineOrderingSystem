using Bolt.Core.Mapping;
using Bolt.Models;

namespace Bolt.DTOs.Products
{
    public class ProductDetailsDTO : IMapFrom<Product>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}