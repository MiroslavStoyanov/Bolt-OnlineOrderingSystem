namespace Bolt.Data.Contexts.Bolt.Interfaces.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::Bolt.Core.Data.Repositories;
    using global::Bolt.DTOs.Users;
    using global::Bolt.Models;

    public interface IUsersRepository : IEFRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);

        Task<User> GetUserByIdAsync(string id);

        Task<List<ListUserViewModel>> GetAllUsersAsync();
    }
}