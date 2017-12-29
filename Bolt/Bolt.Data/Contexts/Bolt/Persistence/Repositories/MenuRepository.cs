using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

using Bolt.Models;
using Bolt.DTOs.Orders;
using Bolt.Core.Data.Repositories;
using Bolt.Data.Contexts.Bolt.Core;
using Bolt.Data.Contexts.Bolt.Core.Repositories;

namespace Bolt.Data.Contexts.Bolt.Persistence.Repositories
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