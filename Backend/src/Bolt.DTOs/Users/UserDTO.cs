using System.Collections;
using System.Collections.Generic;

namespace Bolt.DTOs.Users
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public IEnumerable<string> Roles { get; set; }

        //public List<GetOrderDTO> Orders { get; set; }
    }
}