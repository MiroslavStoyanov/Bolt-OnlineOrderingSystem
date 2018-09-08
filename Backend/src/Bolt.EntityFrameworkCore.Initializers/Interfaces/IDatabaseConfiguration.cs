namespace Bolt.EntityFrameworkCore.Initializers.Interfaces
{
    public interface IDatabaseConfiguration<in TDbContext>
    {
        void Seed(TDbContext context);
    }
}