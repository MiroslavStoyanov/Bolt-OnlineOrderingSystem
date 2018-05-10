namespace Bolt.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Bolt.Core.Data.Repositories;
    using Bolt.Core.Data.Transactions;
    using Bolt.Core.Validation;
    using Bolt.Data.Contexts.Bolt.Interfaces;
    using Bolt.Data.Contexts.Bolt.Interfaces.Repositories;
    using Bolt.DTOs.Orders;
    using Bolt.Models;
    using Bolt.Services.ExceptionHandling;
    using Bolt.Services.Interfaces;

    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork<IBoltDbContext> _unitOfWork;

        public OrdersService(IUnitOfWork<IBoltDbContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<int> ReOrder(int orderId)
        {
            try
            {
                var ordersRepository = this._unitOfWork.GetRepository<IOrdersRepository>();

                GetOrderDTO orderDTO = await ordersRepository.GetOrder(orderId);

                List<OrderLine> orderLines = orderDTO.OrderLines
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
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.ReOrderMessage, ex);
            }
        }

        public async Task<OrderStatus> GetOrderStatusAsync(int orderId)
        {
            try
            {
                var ordersRepository = this._unitOfWork.GetRepository<IOrdersRepository>();

                OrderStatus orderStatus = await ordersRepository.GetOrderStatusAsync(orderId);
                return orderStatus;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.GetOrderStatusAsyncMessage, ex);
            }
        }

        public async Task<int> AddOrderAsync(CreateOrderDTO orderDTO)
        {
            Require.ThatObjectIsNotNull(orderDTO.Products, typeof(ArgumentException),
                ExceptionMessages.AddOrderAsyncProductsNullMessage);

            try
            {
                List<OrderLine> orderLines = orderDTO.Products
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
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.AddOrderAsyncMessage, ex);
            }
        }

        public async Task<List<GetOrderDTO>> GetOrdersForUser(string userId, int numberOfOrdersToTake)
        {
            try
            {
                var ordersRepository = this._unitOfWork.GetRepository<IOrdersRepository>();

                List<GetOrderDTO> orders = await ordersRepository.GetLastOrdersForUser(userId, numberOfOrdersToTake);
                return orders;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.GetOrdersForUserMessage, ex);
            }
        }

        public async Task<List<GetOrderDTO>> GetOrdersForUsername(string username, int numberOfOrdersToTake)
        {
            try
            {
                var ordersRepository = this._unitOfWork.GetRepository<IOrdersRepository>();

                List<GetOrderDTO> orders = await ordersRepository.GetOrdersForUsername(username, numberOfOrdersToTake);
                return orders;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.GetOrdersForUsernameMessage, ex);
            }
        }
    }
}