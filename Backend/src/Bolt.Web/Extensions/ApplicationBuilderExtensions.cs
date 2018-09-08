namespace Bolt.Web.Extensions
{
    using Data.Contexts.Bolt.Implementations;
    using Bolt.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;
    using Infrastructure.Statics;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<BoltDbContext>().Database.Migrate();

                UserManager<User> userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    string administratorRoleName = GlobalConstants.AdministratorRole;

                    bool roleExists = await roleManager.RoleExistsAsync(administratorRoleName);

                    if (!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = administratorRoleName
                        });
                    }

                    User administratorExists = await userManager.FindByNameAsync(administratorRoleName);

                    if (administratorExists == null)
                    {
                        var adminUser = new User
                        {
                            Email = "administrator@bolt.org",
                            UserName = "administrator@bolt.org"
                        };

                        await userManager.CreateAsync(adminUser, "@dmin123");

                        await userManager.AddToRoleAsync(adminUser, administratorRoleName);
                    }
                })
                .GetAwaiter()
                .GetResult();
            }

            return app;
        }
    }
}
