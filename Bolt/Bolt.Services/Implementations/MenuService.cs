namespace Bolt.Services.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Contracts;
    using DTOs.Orders;
    using Data.Contexts.Bolt.Core.Repositories;

    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }

        public async Task<GetMenuDTO> GetMenuAsync()
        {
            try
            {
                GetMenuDTO menu = await this._menuRepository.GetMenuAsync();
                return menu;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went while getting the menu.", ex);
            }
        }
    }
}