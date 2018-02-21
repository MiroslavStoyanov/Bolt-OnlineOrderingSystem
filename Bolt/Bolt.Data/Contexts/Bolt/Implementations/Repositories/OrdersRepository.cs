using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Bolt.Core.Data.Repositories;
using Bolt.Data.Contexts.Bolt.Interfaces;
using Bolt.Data.Contexts.Bolt.Interfaces.Repositories;
using Bolt.DTOs.Orders;
using Bolt.Models;
using Microsoft.EntityFrameworkCore;

namespace Bolt.Data.Contexts.Bolt.Implementations.Repositories
{
    public class OrdersRepository : EFRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(IBoltDbContext context)
            : base(context)
        {
        }

        public async Task<GetOrderDTO> GetOrder(int orderId)
        {
            GetOrderDTO order = await this
                .Where(o => o.Id == orderId)
                .ProjectTo<GetOrderDTO>()
                .FirstOrDefaultAsync();

            return order;
        }

        public async Task<OrderStatus> GetOrderStatusAsync(int orderId)
        {
            OrderStatus orderStatus = await this
                .Where(o => o.Id == orderId)
                .Select(o => o.OrderStatus)
                .FirstOrDefaultAsync();

            return orderStatus;
        }

        public async Task<List<GetOrderDTO>> GetLastOrdersForUser(string userId, int numberOfOrdersToTake)
        {
            List<GetOrderDTO> orders = await this
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedOn)
                .Take(numberOfOrdersToTake)
                .ProjectTo<GetOrderDTO>()
                .ToListAsync();

            return orders;
        }

        public async Task<List<GetOrderDTO>> GetOrdersForUsername(string username, int numberOfOrdersToTake)
        {
            List<GetOrderDTO> orders = await this
                .Where(o => o.User.UserName == username)
                .OrderByDescending(o => o.CreatedOn)
                .Take(numberOfOrdersToTake)
                .ProjectTo<GetOrderDTO>()
                .ToListAsync();

            return orders;
        }
    }
}