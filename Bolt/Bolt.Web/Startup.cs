namespace Bolt.Web
{
    using AutoMapper;
    using Bolt.Core.Data.Repositories;
    using Bolt.Data.Contexts.Bolt.Implementations;
    using Bolt.Data.Contexts.Bolt.Implementations.Repositories;
    using Bolt.Data.Contexts.Bolt.Interfaces;
    using Bolt.Data.Contexts.Bolt.Interfaces.Repositories;
    using Bolt.Models;
    using Bolt.Services.Implementations;
    using Bolt.Services.Interfaces;
    using Bolt.Web.Configuration;
    using Bolt.Web.Extensions;
    using Bolt.Web.Filters;
    using Bolt.Web.Infrastructure.Configurations;
    using Bolt.Web.Services;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Rewrite;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {    
        public IHostingEnvironment HostingEnvironment { get; }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.HostingEnvironment = env;
            this.Configuration = configuration;

            var builder = new ConfigurationBuilder();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISOptions>(options => 
            {
                options.ForwardClientCertificate = false;
            });

            //TODO: Add the Facebook AppId and AppSecret in the userSecrets. If it doesn't work, read the settings from appsettings.json
            services.AddDbContext<BoltDbContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("BoltDatabaseConnection"));
            });

            services.AddIdentity<User, IdentityRole>(options => { options.Password.RequireUppercase = false; })
                .AddEntityFrameworkStores<BoltDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = this.Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = this.Configuration["Authentication:Facebook:AppSecret"];
            });

            services.AddMemoryCache();

            services.AddAutoMapper();

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.Configure<MvcOptions>(options => { options.Filters.Add(new RequireHttpsAttribute()); });

            services.AddMvc(
                options =>
                {
                    options.Filters.Add(typeof(CustomExceptionFilter));
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                })
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizePage("/Account/Logout");
                });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status301MovedPermanently;
                options.HttpsPort = 5001;
            });           

            #region Bolt.Core.Data

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            #endregion

            #region Bolt.Data

            services.AddScoped<IBoltDbContext, BoltDbContext>();

            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            #endregion

            #region Bolt.Services

            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IUsersService, UsersService>();

            #endregion

            services.AddScoped<ICookieCachingService, CookieCachingService>();
            services.AddSingleton<IEmailSender, EmailSender>();
            
            DatabaseConfig.InitializeDatabase(services.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                ExceptionHandlerConfiguration.AddExceptionHandler(app);
            }

            RewriteOptions rewriteOptions = new RewriteOptions().AddRedirectToHttps();

            app.UseRewriter(rewriteOptions);

            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true
            });

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Store}/{action=All}/{id?}");
            });
        }
    }
}