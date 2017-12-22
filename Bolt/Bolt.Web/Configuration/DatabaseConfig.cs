using System;
using Bolt.Data.Contexts.Bolt.Persistence;
using Bolt.Data.DatabaseConfiguration;
using Bolt.EntityFrameworkCore.Initializers;
using Bolt.EntityFrameworkCore.Initializers.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Bolt.Web.Configuration
{
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
