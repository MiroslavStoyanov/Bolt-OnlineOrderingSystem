using Bolt.Models;
using Bolt.Data.Extensions;
using Bolt.Core.Data.Helpers;
using Bolt.Data.Contexts.Bolt.Core;

namespace Bolt.Data.Contexts.Bolt.Persistence
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class BoltDbContext : IdentityDbContext<User>, IBoltDbContext
    {
        public BoltDbContext(DbContextOptions<BoltDbContext> options)
            : base(options)
        {
        }

        //public new DbSet<User> Users { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        public override void Dispose()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Type configurationType = typeof(IBoltDbContextConfiguration);
            Type baseEntityMapType = typeof(IEntityMap);
            modelBuilder.AddFromAssembly(configurationType, baseEntityMapType);
        }
    }
}