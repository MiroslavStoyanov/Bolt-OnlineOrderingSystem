namespace Bolt.Core.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Linq.Expressions;

    using Microsoft.EntityFrameworkCore;

    using Contexts;

    public abstract class EFRepository<TEntity> : IEFRepository<TEntity>
        where TEntity : class
    {
        protected EFRepository(IEFDbContext context)
        {
            this.DbSet = context.Set<TEntity>();
        }

        private DbSet<TEntity> DbSet { get; }

        public IQueryable<TEntity> AsQueryable()
            => this.DbSet.AsQueryable();

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate) 
            => this.DbSet.AsQueryable().Where(predicate);

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
            => await this.DbSet.AsQueryable().AnyAsync(predicate);

        public TEntity GetById(object id)
            => this.DbSet.Find(id);

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
            => this.DbSet.SingleOrDefault(predicate);

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
            => this.DbSet.FirstOrDefault(predicate);

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
            => await this.DbSet.SingleOrDefaultAsync(predicate);

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) 
            => await this.DbSet.FirstOrDefaultAsync(predicate);
    }
}