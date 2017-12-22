namespace Bolt.DTOs.Users
{
    using System.Collections.Generic;

    using Orders;

    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        //public List<GetOrderDTO> Orders { get; set; }
    }
}