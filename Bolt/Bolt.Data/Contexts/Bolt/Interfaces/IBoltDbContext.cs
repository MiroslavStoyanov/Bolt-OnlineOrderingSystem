using Bolt.Core.Data.Contexts;
using Bolt.Models;
using Microsoft.EntityFrameworkCore;

namespace Bolt.Data.Contexts.Bolt.Interfaces
{
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