namespace Bolt.DTOs.Orders
{
    using System;
    using System.Collections.Generic;

    using Products;
    using Models;

    public class GetOrderDTO
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public double TotalPrice { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
    }

    public class CreateOrderDTO
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string UserId { get; set; }

        public ICollection<ProductShoppingCartCache> Products { get; set; }
    }
}