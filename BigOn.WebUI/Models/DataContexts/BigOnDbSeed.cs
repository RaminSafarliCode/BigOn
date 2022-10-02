using BigOn.WebUI.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BigOn.WebUI.Models.DataContexts
{
    public static class BigOnDbSeed
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BigOnDbContext>();
                db.Database.Migrate();

                InitBrands(db);
            }

            return app;
        }

        private static void InitBrands(BigOnDbContext db)
        {
            if (!db.Brands.Any())
            {
                db.Brands.Add(new Brand
                {
                    Name = "Nike"
                });
                db.Brands.Add(new Brand
                {
                    Name = "Adidas"
                });
                db.SaveChanges();
            }
        }
    }
}
