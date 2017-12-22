using System.Threading.Tasks;
using Bolt.Core.Data.Repositories;
using Bolt.DTOs.Menu;
using Bolt.Models;

namespace Bolt.Data.Contexts.Bolt.Core.Repositories
{
    public interface IMenuRepository : IEFRepository<Menu>
    {
        Task<GetMenuDTO> GetMenuAsync();
    }
}