using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Bolt.Core.Data.Repositories;
using Bolt.Data.Contexts.Bolt.Interfaces;
using Bolt.Data.Contexts.Bolt.Interfaces.Repositories;
using Bolt.DTOs.Orders;
using Bolt.Models;
using Microsoft.EntityFrameworkCore;

namespace Bolt.Data.Contexts.Bolt.Implementations.Repositories
{
    public class MenuRepository : EFRepository<Menu>, IMenuRepository
    {
        public MenuRepository(IBoltDbContext context)
            : base(context)
        {
        }

        public async Task<GetMenuDTO> GetMenuAsync()
        {
            GetMenuDTO menuDTO = await this
                .AsQueryable()
                .ProjectTo<GetMenuDTO>()
                .FirstOrDefaultAsync();

            return menuDTO;
        }
    }
}