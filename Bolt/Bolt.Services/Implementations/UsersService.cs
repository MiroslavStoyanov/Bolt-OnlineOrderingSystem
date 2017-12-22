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
    using Core.Data.Repositories;
    using Core.Data.Transactions;
    using Data.Contexts.Bolt.Core;
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
            IUsersRepository usersRepository = this._unitOfWork.GetRepository<IUsersRepository>();

            User user = await usersRepository.GetUserByUsernameAsync(username);
            return Mapper.Map<UserDTO>(user);
        }

        public async Task EditUserAsync(string username, UserDTO model)
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
                // TODO: Change exception
                throw new Exception();
            }
        }

        public async Task<string> GetUserIdByUsernameAsync(string username)
        {
            var usersRepository = this._unitOfWork.GetRepository<IUsersRepository>();

            string userId = await usersRepository
                .Where(u => u.UserName == username)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();

            return userId;
        }
    }
}