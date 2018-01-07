namespace Bolt.Services.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Contracts;
    using Models;
    using DTOs.Orders;
    using Core.Data.Transactions;
    using Core.Data.Repositories;
    using Data.Contexts.Bolt.Core;
    using Data.Contexts.Bolt.Core.Repositories;

    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork<IBoltDbContext> _unitOfWork;

        public OrdersService(IUnitOfWork<IBoltDbContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<int> ReOrder(int orderId)
        {
            IOrdersRepository ordersRepository = this._unitOfWork.GetRepository<IOrdersRepository>();

            GetOrderDTO orderDTO = await ordersRepository.GetOrder(orderId);

            var orderLines = orderDTO.OrderLines
                .Select(p => new OrderLine
                {
                    ProductId = p.Id,
                    Quantity = p.Quantity,
                    ProductName = p.ProductName
                })
                .ToList();

            var order = new Order
            {
                CreatedOn = DateTime.Now,
                OrderStatus = OrderStatus.Accepted,
                UserId = orderDTO.UserId,
                OrderLines = orderLines
            };

            await this._unitOfWork.DbContext.Orders.AddAsync(order);
            await this._unitOfWork.DbContext.SaveChangesAsync();
            CommitTransactionModel response = this._unitOfWork.CommitTransactions();

            return order.Id;
        }

        public async Task<OrderStatus> GetOrderStatusAsync(int orderId)
        {
            IOrdersRepository ordersRepository = this._unitOfWork.GetRepository<IOrdersRepository>();

            OrderStatus orderStatus = await ordersRepository.GetOrderStatusAsync(orderId);
            return orderStatus;
        }

        public async Task<int> AddOrderAsync(CreateOrderDTO orderDTO)
        {
            if (orderDTO.Products == null)
            {
                throw new ArgumentException("The products in the Order DTO are null.");
            }

            var orderLines = orderDTO.Products
                .Select(p => new OrderLine
                {
                    ProductId = p.Id,
                    Quantity = p.Quantity,
                    ProductName = p.ProductName
                })
                .ToList();

            var order = new Order
            {
                CreatedOn = orderDTO.CreatedOn,
                OrderStatus = orderDTO.OrderStatus,
                UserId = orderDTO.UserId,
                OrderLines = orderLines
            };

            await this._unitOfWork.DbContext.Orders.AddAsync(order);
            await this._unitOfWork.DbContext.SaveChangesAsync();
            CommitTransactionModel response = this._unitOfWork.CommitTransactions();

            return order.Id;
        }

        public async Task<List<GetOrderDTO>> GetOrdersForUser(string userId, int numberOfOrdersToTake)
        {
            IOrdersRepository ordersRepository = this._unitOfWork.GetRepository<IOrdersRepository>();

            List<GetOrderDTO> orders = await ordersRepository.GetLastOrdersForUser(userId, numberOfOrdersToTake);
            return orders;
        }

        public async Task<List<GetOrderDTO>> GetOrdersForUsername(string username, int numberOfOrdersToTake)
        {
            IOrdersRepository ordersRepository = this._unitOfWork.GetRepository<IOrdersRepository>();

            List<GetOrderDTO> orders = await ordersRepository.GetOrdersForUsername(username, numberOfOrdersToTake);
            return orders;
        }
    }
}