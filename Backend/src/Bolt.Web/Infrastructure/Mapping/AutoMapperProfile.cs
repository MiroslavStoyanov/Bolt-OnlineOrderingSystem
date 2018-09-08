namespace Bolt.Web.Infrastructure.Mapping
{
    using System.Linq;

    using AutoMapper;

    using Bolt.Models;
    using DTOs.Users;
    using DTOs.Orders;
    using DTOs.Products;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // TODO: Fix reflection
            this.CreateMap<Menu, GetMenuDTO>()
                .ForMember(c => c.Products, cfg => cfg.MapFrom(c => c.Products.ToList()));

            this.CreateMap<Product, ProductDetailsDTO>();
            this.CreateMap<Product, ProductDTO>();

            this.CreateMap<User, UserDTO>();
            this.CreateMap<User, ListUserViewModel>();
            //.ForMember(c => c.Orders, cfg => cfg.MapFrom(c => c.Orders.Select(o => Mapper.Map<Order, GetOrderDTO>(o)).ToList()));

            //    IEnumerable<Type> allTypes = AppDomain
            //        .CurrentDomain
            //        .GetAssemblies()
            //        .Where(x => x.GetName().Name.Contains("Bolt"))
            //        .SelectMany(a => a.GetTypes());

            //    allTypes.Where(t => t.IsClass
            //        && !t.IsAbstract
            //        && t.GetInterfaces().Where(i => t.IsGenericType)
            //            .Select(i => i.GetGenericTypeDefinition())
            //        .Contains(typeof(IMapFrom<>)))
            //    .Select(t => new
            //    {
            //        Destination = t,
            //        Source = t
            //            .GetInterfaces()
            //            .Where(i => i.IsGenericType)
            //            .Select(i => new
            //            {
            //                Definition = i.GetGenericTypeDefinition(),
            //                Arguments = i.GetGenericArguments()
            //            })
            //            .Where(i => i.Definition == typeof(IMapFrom<>))
            //            .SelectMany(i => i.Arguments)
            //            .First(),
            //    })
            //    .ToList()
            //    .ForEach(t => this.CreateMap(t.Source, t.Destination));

            //    allTypes
            //        .Where(t => t.IsClass
            //                    && !t.IsAbstract
            //                    && typeof(IHaveCustomMapping).IsAssignableFrom(t))
            //        .Select(Activator.CreateInstance)
            //        .Cast<IHaveCustomMapping>()
            //        .ToList()
            //        .ForEach(mapping => mapping.ConfigureMapping(this));
        }
    }
}
