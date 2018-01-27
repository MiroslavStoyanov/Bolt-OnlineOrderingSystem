namespace Bolt.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderLine
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required]
        [MaxLength(20)]
        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}
