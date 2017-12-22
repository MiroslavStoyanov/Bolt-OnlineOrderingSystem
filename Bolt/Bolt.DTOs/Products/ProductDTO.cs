namespace Bolt.DTOs.Products
{
    using Core.Mapping;
    using Models;

    public class ProductDTO : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}