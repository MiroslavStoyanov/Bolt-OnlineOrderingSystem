namespace Bolt.Services.Interfaces
{
    using System.Threading.Tasks;
    using DTOs.Orders;

    public interface IMenuService
    {
        Task<GetMenuDTO> GetMenuAsync();
    }
}