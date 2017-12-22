namespace Bolt.EntityFrameworkCore.Initializers.Extensions
{
    using Microsoft.EntityFrameworkCore;

    using Contracts;

    public static class DbContextExtensions
    {
        public static void SetInitializer<TDbContext, TDatabaseInitializer>(this TDbContext dbContext,
            TDatabaseInitializer dbInitialize)
            where TDbContext : DbContext
            where TDatabaseInitializer : IDatabaseInitializer<TDbContext>
        {
            dbInitialize.InitializeDatabase(dbContext);
        }
    }
}