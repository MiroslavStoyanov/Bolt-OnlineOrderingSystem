namespace Bolt.Services.Implementations
{
    using System;
    using System.Threading.Tasks;
    using Bolt.Core.Data.Repositories;
    using Bolt.Data.Contexts.Bolt.Interfaces;
    using Bolt.Data.Contexts.Bolt.Interfaces.Repositories;
    using Bolt.DTOs.Orders;
    using Bolt.Services.ExceptionHandling;
    using Bolt.Services.Interfaces;

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
                var menuRepository = this._unitOfWork.GetRepository<IMenuRepository>();

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