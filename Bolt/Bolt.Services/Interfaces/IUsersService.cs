using System.Threading.Tasks;
using Bolt.DTOs.Users;

namespace Bolt.Services.Interfaces
{
    public interface IUsersService
    {
        Task<UserDTO> GetUserByUsernameAsync(string username);

        Task EditUserAsync(string username, UserDTO model);

        Task<string> GetUserIdByUsernameAsync(string username);
    }
}