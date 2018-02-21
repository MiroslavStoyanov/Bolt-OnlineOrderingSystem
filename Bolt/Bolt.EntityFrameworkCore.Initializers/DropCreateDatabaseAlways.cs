using Bolt.EntityFrameworkCore.Initializers.Interfaces;

namespace Bolt.EntityFrameworkCore.Initializers
{
    using Microsoft.EntityFrameworkCore;

    public class DropCreateDatabaseAlways<TDbContext> : IDatabaseInitializer<TDbContext>
        where TDbContext : DbContext
    {
        private readonly IDatabaseConfiguration<TDbContext> _initializerConfiguration;

        public DropCreateDatabaseAlways(IDatabaseConfiguration<TDbContext> initializerConfiguration)
        {
            this._initializerConfiguration = initializerConfiguration;
        }

        public void InitializeDatabase(TDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            this._initializerConfiguration.Seed(dbContext);
        }
    }
}