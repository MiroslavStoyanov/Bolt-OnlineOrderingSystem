namespace Bolt.Models
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        //public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}