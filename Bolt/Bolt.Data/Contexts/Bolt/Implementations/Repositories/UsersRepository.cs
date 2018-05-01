using System.Threading.Tasks;
using Bolt.Core.Data.Repositories;
using Bolt.Data.Contexts.Bolt.Interfaces;
using Bolt.Data.Contexts.Bolt.Interfaces.Repositories;
using Bolt.Models;
using Microsoft.EntityFrameworkCore;

namespace Bolt.Data.Contexts.Bolt.Implementations.Repositories
{
    public class UsersRepository : EFRepository<User>, IUsersRepository
    {
        public UsersRepository(IBoltDbContext context)
            : base(context)
        {
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            User user = await this
                .Where(u => u.UserName == username)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            User user = await this
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            return user;
        }

        //TODO: Add another method here to get all repositories
    }
}