namespace Bolt.Data.Contexts.Bolt.Implementations.Repositories
{
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using global::Bolt.Core.Data.Repositories;
    using global::Bolt.Data.Contexts.Bolt.Interfaces;
    using global::Bolt.Data.Contexts.Bolt.Interfaces.Repositories;
    using global::Bolt.DTOs.Orders;
    using global::Bolt.Models;
    using Microsoft.EntityFrameworkCore;

    public class MenuRepository : EFRepository<Menu>, IMenuRepository
    {
        public MenuRepository(IBoltDbContext context)
            : base(context)
        {
        }

        public async Task<GetMenuDTO> GetMenuAsync()
        {
            GetMenuDTO menuDto = await AsQueryable()
                .ProjectTo<GetMenuDTO>()
                .FirstOrDefaultAsync();

            return menuDto;
        }
    }
}