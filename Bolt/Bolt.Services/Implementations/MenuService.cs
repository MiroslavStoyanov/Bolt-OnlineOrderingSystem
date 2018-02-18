using Bolt.Services.ExceptionHandling;
using Bolt.Services.Interfaces;

namespace Bolt.Services.Implementations
{
    using System;
    using System.Threading.Tasks;
    using DTOs.Orders;
    using Core.Data.Repositories;
    using Data.Contexts.Bolt.Core;
    using Data.Contexts.Bolt.Core.Repositories;

    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork<IBoltDbContext> _unitOfWork;

        public MenuService(IUnitOfWork<IBoltDbContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<GetMenuDTO> GetMenuAsync()
        {
            try
            {
                IMenuRepository menuRepository = this._unitOfWork.GetRepository<IMenuRepository>();

                GetMenuDTO menu = await menuRepository.GetMenuAsync();

                return menu;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ExceptionMessages.GetMenuAsyncMessage, ex);
            }
        }
    }
}