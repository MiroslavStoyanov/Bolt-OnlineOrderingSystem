namespace Bolt.EntityFrameworkCore.Initializers
{
    using Bolt.EntityFrameworkCore.Initializers.Interfaces;
    using Microsoft.EntityFrameworkCore;

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
            if (dbContext.Database != null)
            {
                this._initializerConfiguration.Seed(dbContext);
            }
            else
            {
                dbContext.Database.EnsureCreated();
                this._initializerConfiguration.Seed(dbContext);
            }
        }
    }
}