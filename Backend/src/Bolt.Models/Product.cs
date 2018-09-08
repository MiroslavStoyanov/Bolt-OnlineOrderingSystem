namespace Bolt.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.OrderLines = new HashSet<OrderLine>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}