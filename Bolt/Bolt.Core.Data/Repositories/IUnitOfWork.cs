using Bolt.Core.Data.Contexts;
using Bolt.Core.Data.Transactions;

namespace Bolt.Core.Data.Repositories
{
    public interface IUnitOfWork<TDbContext>
        where TDbContext : IEFDbContext
    {
        TDbContext DbContext { get; set; }

        TRepository GetRepository<TRepository>() where TRepository : class;

        CommitTransactionModel CommitTransactions();

        void RollbackTransactions();
    }
}