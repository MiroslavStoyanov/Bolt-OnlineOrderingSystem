using Bolt.Data.Contexts.Bolt.Interfaces;
using Bolt.Data.Contexts.Bolt.Interfaces.Repositories;
using Bolt.Services.ExceptionHandling;
using Bolt.Services.Interfaces;

namespace Bolt.Services.Implementations
{
    using System;
    using System.Threading.Tasks;
    using DTOs.Orders;
    using Core.Data.Repositories;

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