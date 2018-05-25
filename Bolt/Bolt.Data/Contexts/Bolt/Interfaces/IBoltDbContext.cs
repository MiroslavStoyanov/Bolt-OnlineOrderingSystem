namespace Bolt.Data.Contexts.Bolt.Interfaces
{
    using global::Bolt.Core.Data.Contexts;
    using global::Bolt.Models;
    using Microsoft.EntityFrameworkCore;

    public interface IBoltDbContext : IEFDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Menu> Menus { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<OrderLine> OrderLines { get; set; }

        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);
    }
}