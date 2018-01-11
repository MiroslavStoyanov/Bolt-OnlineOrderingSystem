namespace Bolt.Services.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Contracts;
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
                throw new ArgumentException("Getting the menu has failed. Please try again.", ex);
            }
        }
    }
}