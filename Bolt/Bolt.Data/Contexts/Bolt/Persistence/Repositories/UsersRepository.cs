using System.Threading.Tasks;
using Bolt.Core.Data.Repositories;
using Bolt.Data.Contexts.Bolt.Core;
using Bolt.Data.Contexts.Bolt.Core.Repositories;
using Bolt.Models;
using Microsoft.EntityFrameworkCore;

namespace Bolt.Data.Contexts.Bolt.Persistence.Repositories
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
    }
}