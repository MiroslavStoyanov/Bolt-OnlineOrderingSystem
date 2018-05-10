namespace Bolt.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Bolt.Core.Data.Repositories;
    using Bolt.Core.Data.Transactions;
    using Bolt.Core.Validation;
    using Bolt.Data.Contexts.Bolt.Interfaces;
    using Bolt.Data.Contexts.Bolt.Interfaces.Repositories;
    using Bolt.DTOs.Users;
    using Bolt.Models;
    using Bolt.Services.ExceptionHandling;
    using Bolt.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork<IBoltDbContext> _unitOfWork;

        public UsersService(IUnitOfWork<IBoltDbContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> GetUserByUsernameAsync(string username)
        {
            Require.ThatStringIsNotNullOrEmpty(username, typeof(ArgumentException),
                ExceptionMessages.GetUserByUsernameNullStringMessage);

            try
            {
                var usersRepository = this._unitOfWork.GetRepository<IUsersRepository>();

                User user = await usersRepository.GetUserByUsernameAsync(username);

                return Mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.GetUserByUsernameMessage, ex);
            }
        }

        public async Task EditUserAsync(string username, UserDTO model)
        {
            Require.ThatStringIsNotNullOrEmpty(username, typeof(ArgumentException),
                ExceptionMessages.EditUserAsyncUsernameNullMessage);
            Require.ThatObjectIsNotNull(model, typeof(ArgumentNullException),
                ExceptionMessages.EditUserAsyncModelNullMessage);

            try
            {
                var usersRepository = this._unitOfWork.GetRepository<IUsersRepository>();

                User user = await usersRepository.GetUserByUsernameAsync(username);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Country = model.Country;
                user.Town = model.Town;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;

                await this._unitOfWork.DbContext.SaveChangesAsync(false);
                CommitTransactionModel commitTransaction = this._unitOfWork.CommitTransactions();

                if (commitTransaction == null || !commitTransaction.IsSuccessful)
                {
                    throw new ArgumentException(ExceptionMessages.CommitTransactionMessage,
                        commitTransaction?.CommitException);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.EditUserMessage, ex);
            }
        }

        public async Task<string> GetUserIdByUsernameAsync(string username)
        {
            Require.ThatStringIsNotNullOrEmpty(username, typeof(ArgumentException),
                ExceptionMessages.GetUserIdByUsernameNullUsernameMessage);

            try
            {
                var usersRepository = this._unitOfWork.GetRepository<IUsersRepository>();

                string userId = await usersRepository
                    .Where(u => u.UserName == username)
                    .Select(u => u.Id)
                    .FirstOrDefaultAsync();

                return userId;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.GetUserIdByUsernameMessage, ex);
            }
        }

        public async Task<List<ListUserViewModel>> GetAllUsersAsync()
        {
            var usersRepository = this._unitOfWork.GetRepository<IUsersRepository>();

            List<ListUserViewModel> users = await usersRepository
                .GetAllUsersAsync();

            return users.ToList();
        }
    }
}