namespace Bolt.Web.ViewModels.UserSettings
{
    using System.Collections.Generic;

    using DTOs.Users;
    using DTOs.Orders;

    public class UserSettingsViewModel
    {
        public UserSettingsViewModel()
            : this(null, new List<GetOrderDTO>())
        {
        }

        public UserSettingsViewModel(UserDTO user, List<GetOrderDTO> orders)
        {
            this.User = user;
            this.Orders = orders;
        }

        public UserDTO User { get; set; }

        public List<GetOrderDTO> Orders { get; set; }
    }
}
