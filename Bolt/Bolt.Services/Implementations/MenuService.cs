namespace Bolt.Services.Implementations
{
    using System.Threading.Tasks;

    using DTOs.Menu;
    using Contracts;
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
            GetMenuDTO menu = await this._menuRepository.GetMenuAsync();
            return menu;
        }
    }
}