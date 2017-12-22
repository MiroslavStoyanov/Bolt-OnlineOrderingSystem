using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Bolt.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddFromAssembly(this ModelBuilder modelBuilder, Type configurationType,
            Type baseEntityMapType)
        {
            Type[] maps = configurationType.GetTypeInfo().Assembly.GetTypes()
                .Where(type => !string.IsNullOrWhiteSpace(type.Namespace)
                               && baseEntityMapType.IsAssignableFrom(type)
                               && type.GetTypeInfo().ImplementedInterfaces
                                   .Count(ii => ii.IsAssignableFrom(configurationType)) != 0)
                .ToArray();

            foreach (Type item in maps)
            {
                Activator.CreateInstance(item, modelBuilder);
            }
        }
    }
}