namespace Bolt.EntityFrameworkCore.Initializers.Contracts
{
    using Microsoft.EntityFrameworkCore;

    public interface IDatabaseInitializer<in TDbContext>
        where TDbContext : DbContext
    {
        /// <summary>
        ///     Executes the strategy to initialize the database for the given context.
        /// </summary>
        /// <param name="dbContext"> The database context. </param>
        void InitializeDatabase(TDbContext dbContext);
    }
}