namespace Bolt.EntityFrameworkCore.Initializers.Managers
{
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    internal class MigrationsManager
    {
        internal static void MigrateAllPendingChanges(DbContext dbContext)
        {
            string[] pendingMigrations = GetPendingMigrations(dbContext);

            if (!pendingMigrations.Any())
            {
                return;
            }

            var migrator = dbContext.Database.GetService<IMigrator>();

            foreach (string targetMigration in pendingMigrations)
            {
                migrator.Migrate(targetMigration);
            }
        }

        private static string[] GetPendingMigrations(DbContext dbContext)
        {
            return dbContext.Database
                .GetPendingMigrations()
                .ToArray();
        }
    }
}