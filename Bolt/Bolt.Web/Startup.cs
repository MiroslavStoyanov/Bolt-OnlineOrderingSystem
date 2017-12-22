﻿namespace Bolt.Web
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Authentication.Cookies;

    using Bolt.Models;
    using Bolt.Web.Services;
    using Bolt.Web.Configuration;
    using Bolt.Services.Contracts;
    using Bolt.Core.Data.Repositories;
    using Bolt.Data.Contexts.Bolt.Core;
    using Bolt.Services.Implementations;
    using Bolt.Data.Contexts.Bolt.Persistence;
    using Bolt.Data.Contexts.Bolt.Core.Repositories;
    using Bolt.Data.Contexts.Bolt.Persistence.Repositories;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BoltDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("BoltDatabaseConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BoltDbContext>()
                .AddDefaultTokenProviders();

            services.AddMemoryCache();

            services.AddAutoMapper();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddMvc(options => options.Filters
                .Add<AutoValidateAntiforgeryTokenAttribute>())
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizePage("/Account/Logout");
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

            services.AddScoped<CookieCachingService>();
            services.AddSingleton<IEmailSender, EmailSender>();

            DatabaseConfig.InitializeDatabase(services.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Store}/{action=Index}/{id?}");
            });
        }
    }
}