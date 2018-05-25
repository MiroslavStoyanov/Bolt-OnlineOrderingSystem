namespace Bolt.Core.Data.Repositories
{
    using Bolt.Core.Data.Contexts;
    using Bolt.Core.Data.Transactions;

    public interface IUnitOfWork<TDbContext>
        where TDbContext : IEFDbContext
    {
        TDbContext DbContext { get; set; }

        TRepository GetRepository<TRepository>() where TRepository : class;

        CommitTransactionModel CommitTransactions();

        void RollbackTransactions();
    }
}