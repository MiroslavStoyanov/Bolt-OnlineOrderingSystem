namespace Bolt.Services.Contracts
{
    using System.Threading.Tasks;

    using DTOs.Orders;

    public interface IMenuService
    {
        Task<GetMenuDTO> GetMenuAsync();
    }
}