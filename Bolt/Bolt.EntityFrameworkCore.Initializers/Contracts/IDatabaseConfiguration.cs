namespace Bolt.EntityFrameworkCore.Initializers.Contracts
{
    public interface IDatabaseConfiguration<in TDbContext>
    {
        void Seed(TDbContext context);
    }
}