using Bolt.EntityFrameworkCore.Initializers.Interfaces;

namespace Bolt.EntityFrameworkCore.Initializers.Extensions
{
    using Microsoft.EntityFrameworkCore;

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