using System.Collections;
using System.Collections.Generic;

namespace Bolt.DTOs.Users
{
    public class ListUserViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
