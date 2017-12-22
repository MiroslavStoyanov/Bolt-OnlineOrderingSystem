using System.Threading.Tasks;
using Bolt.Core.Data.Repositories;
using Bolt.Models;

namespace Bolt.Data.Contexts.Bolt.Core.Repositories
{
    public interface IUsersRepository : IEFRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);

        Task<User> GetUserByIdAsync(string id);
    }
}