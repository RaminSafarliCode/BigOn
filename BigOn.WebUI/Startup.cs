using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.AppCode.Services;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities.Membership;
using MediatR;
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
                foreach (var item in Extension.policies)
                {
                    cfg.AddPolicy(item, p =>
                    {
                        // p.RequireClaim(item, "1");

                        p.RequireAssertion(ra =>
                        {
                            return ra.User.HasAccess(item);
                        });
                    });
                }

            });


            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });

            services.Configure<CryptoServiceOptions>(cfg =>
            {
                configuration.GetSection("cryptography").Bind(cfg);
            });
            services.AddSingleton<CryptoService>();

            services.Configure<EmailServiceOptions>(cfg =>
            {
                configuration.GetSection("emailAccount").Bind(cfg);
            });
            services.AddSingleton<EmailService>();


            var asemblies = AppDomain.CurrentDomain.GetAssemblies().AsEnumerable().Where(a => a.FullName.StartsWith("BigOn."));

            services.AddMediatR(asemblies.ToArray());
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
                cfg.MapAreaControllerRoute("defaultAdmin", "admin", "admin/{controller=dashboard}/{action=index}/{id?}");
                cfg.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
