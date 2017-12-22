using System.Threading.Tasks;
using Bolt.DTOs.Menu;

namespace Bolt.Services.Contracts
{
    public interface IMenuService
    {
        Task<GetMenuDTO> GetMenuAsync();
    }
}