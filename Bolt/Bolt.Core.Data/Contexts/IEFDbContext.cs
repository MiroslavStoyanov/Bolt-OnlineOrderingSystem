using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Bolt.Core.Data.Contexts
{
    public interface IEFDbContext
    {
        DatabaseFacade Database { get; }

        void Dispose();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}