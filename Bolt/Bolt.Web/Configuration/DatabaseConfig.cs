namespace Bolt.Web.Configuration
{
    using System;
    using Data.Contexts.Bolt.Implementations;
    using Microsoft.Extensions.DependencyInjection;
    using Data.DatabaseConfiguration;
    using EntityFrameworkCore.Initializers;
    using EntityFrameworkCore.Initializers.Extensions;

    public static class DatabaseConfig
    {
        public static void InitializeDatabase(IServiceProvider serviceProvider)
        {
            // TODO: Check environments

            var boltDbContext = serviceProvider.GetService<BoltDbContext>();
            
            boltDbContext.SetInitializer(
                new DropCreateDatabaseAlways<BoltDbContext>(new BoltDatabaseConfiguration()));

        }
    }
}
