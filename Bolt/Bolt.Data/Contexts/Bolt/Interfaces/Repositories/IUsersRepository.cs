using System.Collections.Generic;
using System.Threading.Tasks;
using Bolt.Core.Data.Repositories;
using Bolt.DTOs.Users;
using Bolt.Models;

namespace Bolt.Data.Contexts.Bolt.Interfaces.Repositories
{
    public interface IUsersRepository : IEFRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);

        Task<User> GetUserByIdAsync(string id);

        Task<List<ListUserViewModel>> GetAllUsersAsync();
    }
}