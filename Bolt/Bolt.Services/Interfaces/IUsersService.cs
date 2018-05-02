namespace Bolt.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Bolt.DTOs.Users;

    public interface IUsersService
    {
        Task<UserDTO> GetUserByUsernameAsync(string username);

        Task EditUserAsync(string username, UserDTO model);

        Task<string> GetUserIdByUsernameAsync(string username);

        Task<List<ListUserViewModel>> GetAllUsersAsync();
    }
}