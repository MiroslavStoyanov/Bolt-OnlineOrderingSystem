namespace Bolt.Services.Contracts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models;
    using DTOs.Orders;

    public interface IOrdersService
    {
        Task<int> ReOrder(int orderId);

        Task<OrderStatus> GetOrderStatusAsync(int orderId);

        Task<int> AddOrderAsync(CreateOrderDTO orderDTO);

        Task<List<GetOrderDTO>> GetOrdersForUser(string userId, int numberOfOrdersToTake);
    }
}