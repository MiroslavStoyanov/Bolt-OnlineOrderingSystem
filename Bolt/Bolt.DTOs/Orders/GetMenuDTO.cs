namespace Bolt.DTOs.Menu
{
    using System.Collections.Generic;

    using Models;
    using Core.Mapping;

    public class GetMenuDTO : IMapFrom<Menu>
    {
        public List<Product> Products { get; set; }
    }
}