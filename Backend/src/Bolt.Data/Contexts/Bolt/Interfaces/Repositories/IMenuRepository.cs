namespace Bolt.Data.Contexts.Bolt.Interfaces.Repositories
{
    using System.Threading.Tasks;
    using global::Bolt.Core.Data.Repositories;
    using global::Bolt.DTOs.Orders;
    using global::Bolt.Models;

    public interface IMenuRepository : IEFRepository<Menu>
    {
        Task<GetMenuDTO> GetMenuAsync();
    }
}