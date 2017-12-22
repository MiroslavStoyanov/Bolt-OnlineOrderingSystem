namespace Bolt.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderLine
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}
