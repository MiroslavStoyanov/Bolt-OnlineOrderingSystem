namespace Bolt.Services.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using DTOs.Users;
    using Models;
    using Core.Validation;
    using ExceptionHandling;
    using Core.Data.Repositories;
    using Core.Data.Transactions;
    using Data.Contexts.Bolt.Core;
    using ExceptionHandling.Exceptions;
    using Data.Contexts.Bolt.Core.Repositories;

    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork<IBoltDbContext> _unitOfWork;

        public UsersService(IUnitOfWork<IBoltDbContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> GetUserByUsernameAsync(string username)
        {
            Require.ThatStringIsNotNullOrEmpty(username, typeof(GetUserByUsernameException), ServicesErrorCodes.GetUserByUsernameNullString);

            try
            {
                IUsersRepository usersRepository = this._unitOfWork.GetRepository<IUsersRepository>();

                User user = await usersRepository.GetUserByUsernameAsync(username);

                return Mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new GetUserByUsernameException(ServicesErrorCodes.GetUserByUsername, ex);
            }
        }

        public async Task EditUserAsync(string username, UserDTO model)
        {
            Require.ThatStringIsNotNullOrEmpty(username, typeof(EditUserAsyncException), ServicesErrorCodes.EditUserAsyncUsernameNull);
            Require.ThatObjectIsNotNull(model, typeof(EditUserAsyncException), ServicesErrorCodes.EditUserAsyncModelNull);

            try
            {
                IUsersRepository usersRepository = this._unitOfWork.GetRepository<IUsersRepository>();

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
                    throw new EditUserAsyncException(ServicesErrorCodes.CommitTransaction, commitTransaction?.CommitException);
                }
            }
            catch (Exception ex)
            {
                throw new EditUserAsyncException(ServicesErrorCodes.EditUser, ex);
            }
        }

        public async Task<string> GetUserIdByUsernameAsync(string username)
        {
            Require.ThatStringIsNotNullOrEmpty(username, typeof(GetUserIdByUsernameException), ServicesErrorCodes.GetUserIdByUsernameNullUsername);

            try
            {
                IUsersRepository usersRepository = this._unitOfWork.GetRepository<IUsersRepository>();

                string userId = await usersRepository
                    .Where(u => u.UserName == username)
                    .Select(u => u.Id)
                    .FirstOrDefaultAsync();

                return userId;
            }
            catch (Exception ex)
            {
                throw new GetUserIdByUsernameException(ServicesErrorCodes.GetUserIdByUsername, ex);
            }
        }
    }
}