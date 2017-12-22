namespace Bolt.Core.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore.Storage;

    using Contexts;
    using Transactions;

    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext>
        where TDbContext : IEFDbContext
    {
        private readonly Dictionary<Type, object> _repositories;
        private readonly IDbContextTransaction _transaction;

        public UnitOfWork(TDbContext dbContext)
        {
            this._repositories = new Dictionary<Type, object>();
            this._transaction = dbContext.Database.BeginTransactionAsync().Result;
            this.DbContext = dbContext;
        }

        public virtual TDbContext DbContext { get; set; }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            if (this._repositories.ContainsKey(typeof(TRepository)))
            {
                return this._repositories[typeof(TRepository)] as TRepository;
            }

            Type selectedType = typeof(TRepository).Assembly.GetTypes()
                .FirstOrDefault(type => typeof(TRepository).IsAssignableFrom(type)
                                        && type.GetTypeInfo().IsClass);

            ConstructorInfo constructor = selectedType.GetConstructors().First();

            if (constructor.GetParameters().Length == 1)
            {
                this._repositories.Add(typeof(TRepository), Activator.CreateInstance(selectedType, this.DbContext));
            }
            else
            {
                this._repositories.Add(typeof(TRepository), Activator.CreateInstance(selectedType, this.DbContext));
            }

            return this._repositories[typeof(TRepository)] as TRepository;
        }

        public CommitTransactionModel CommitTransactions()
        {
            CommitTransactionModel commitTransaction = this.CommitAllTransactions();

            if (commitTransaction == null || !commitTransaction.IsSuccessful)
            {
                this.RollbackTransactions();
            }

            return commitTransaction;
        }

        public virtual void RollbackTransactions() => this._transaction.Rollback();

        internal virtual CommitTransactionModel CommitAllTransactions()
        {
            var commitTransactionModel = new CommitTransactionModel();

            if (this._transaction == null)
            {
                return commitTransactionModel;
            }

            if (this._transaction.GetDbTransaction().Connection != null)
            {
                this._transaction.Commit();
            }

            return commitTransactionModel;
        }
    }
}