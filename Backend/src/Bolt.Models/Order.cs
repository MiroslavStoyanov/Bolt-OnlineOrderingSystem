namespace Bolt.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        public Order()
        {
            this.OrderLines = new HashSet<OrderLine>();
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        // TODO: Consider if it will be NotMapped
        [NotMapped]
        public double TotalPrice { get; set; }
        //{
        //    get { return this.OrderLines.Sum(p => p.Product.Price); }
        //}

        public OrderStatus OrderStatus { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}