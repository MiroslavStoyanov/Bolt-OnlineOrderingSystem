using System.Collections.Generic;
using System.Threading.Tasks;
using Bolt.Core.Data.Repositories;
using Bolt.DTOs.Orders;
using Bolt.Models;

namespace Bolt.Data.Contexts.Bolt.Interfaces.Repositories
{
    public interface IOrdersRepository : IEFRepository<Order>
    {
        Task<GetOrderDTO> GetOrder(int orderId);

        Task<OrderStatus> GetOrderStatusAsync(int orderId);

        Task<List<GetOrderDTO>> GetLastOrdersForUser(string userId, int numberOfOrdersToTake);

        Task<List<GetOrderDTO>> GetOrdersForUsername(string username, int numberOfOrdersToTake);
    }
}