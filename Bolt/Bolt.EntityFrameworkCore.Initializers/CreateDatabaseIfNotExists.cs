using Bolt.EntityFrameworkCore.Initializers.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Bolt.EntityFrameworkCore.Initializers
{
    public class CreateDatabaseIfNotExists<TDbContext> : IDatabaseInitializer<TDbContext>
        where TDbContext : DbContext
    {
        private readonly IDatabaseConfiguration<TDbContext> _initializerConfiguration;

        public CreateDatabaseIfNotExists(IDatabaseConfiguration<TDbContext> initializerConfiguration)
        {
            this._initializerConfiguration = initializerConfiguration;
        }

        public void InitializeDatabase(TDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            this._initializerConfiguration.Seed(dbContext);
        }
    }
}