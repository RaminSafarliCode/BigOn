using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigOn.WebUI
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(cfg =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));   
            });

            services.AddDbContext<BigOnDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration["ConnectionStrings:cString"]);
            });

            services.SetupIdentity();

            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("admin.brands.index", p => {
                    p.RequireClaim("admin.brands.index", "1");
                });
                cfg.AddPolicy("admin.brands.details", p => {
                    p.RequireClaim("admin.brands.details", "1");
                });
                cfg.AddPolicy("admin.brands.create", p => {
                    p.RequireClaim("admin.brands.create", "1");
                });
                cfg.AddPolicy("admin.brands.edit", p => {
                    p.RequireClaim("admin.brands.edit", "1");
                });
                cfg.AddPolicy("admin.brands.remove", p => {
                    p.RequireClaim("admin.brands.remove", "1");
                });
            });


            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // DataBase Seeding - create environment to upload default data in our database
            app.SeedData();
            app.SeedMembership();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapAreaControllerRoute("defaultAdmin", "admin" ,"admin/{controller=dashboard}/{action=index}/{id?}");
                cfg.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
