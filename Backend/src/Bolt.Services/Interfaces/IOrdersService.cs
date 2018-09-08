using System.Collections.Generic;
using System.Threading.Tasks;
using Bolt.DTOs.Orders;
using Bolt.Models;

namespace Bolt.Services.Interfaces
{
    public interface IOrdersService
    {
        Task<int> ReOrder(int orderId);

        Task<OrderStatus> GetOrderStatusAsync(int orderId);

        Task<int> AddOrderAsync(CreateOrderDTO orderDTO);

        Task<List<GetOrderDTO>> GetOrdersForUser(string userId, int numberOfOrdersToTake);

        Task<List<GetOrderDTO>> GetOrdersForUsername(string username, int numberOfOrdersToTake);
    }
}