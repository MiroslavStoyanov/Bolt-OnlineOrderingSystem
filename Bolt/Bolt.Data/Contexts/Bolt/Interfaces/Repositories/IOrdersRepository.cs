namespace Bolt.Data.Contexts.Bolt.Interfaces.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::Bolt.Core.Data.Repositories;
    using global::Bolt.DTOs.Orders;
    using global::Bolt.Models;

    public interface IOrdersRepository : IEFRepository<Order>
    {
        Task<GetOrderDTO> GetOrder(int orderId);

        Task<OrderStatus> GetOrderStatusAsync(int orderId);

        Task<List<GetOrderDTO>> GetLastOrdersForUser(string userId, int numberOfOrdersToTake);

        Task<List<GetOrderDTO>> GetOrdersForUsername(string username, int numberOfOrdersToTake);
    }
}