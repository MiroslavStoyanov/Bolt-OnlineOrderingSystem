namespace Bolt.EntityFrameworkCore.Initializers
{
    using Microsoft.EntityFrameworkCore;

    using Managers;
    using Contracts;

    public class MigrateDatabaseToLatestVersion<TDbContext> : IDatabaseInitializer<TDbContext>
        where TDbContext : DbContext
    {
        private readonly IDatabaseConfiguration<TDbContext> _initializerConfiguration;

        public MigrateDatabaseToLatestVersion(IDatabaseConfiguration<TDbContext> initializerConfiguration)
        {
            this._initializerConfiguration = initializerConfiguration;
        }

        public void InitializeDatabase(TDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            MigrationsManager.MigrateAllPendingChanges(dbContext);

            this._initializerConfiguration.Seed(dbContext);
        }
    }
}