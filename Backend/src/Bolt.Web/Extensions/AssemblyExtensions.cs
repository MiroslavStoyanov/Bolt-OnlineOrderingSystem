using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace Bolt.Web.Extensions
{
    public static class AssemblyExtensions
    {
        private static IEnumerable<AssemblyName> GetAssemblyNames()
        {
            return DependencyContext.Default
                .GetDefaultAssemblyNames()
                .Where(a => a.FullName.StartsWith("Bolt."));
        }

        public static IEnumerable<Assembly> GetAssemblies() => GetAssemblyNames().Select(Assembly.Load);
    }
}
