using BigOn.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigOn.WebUI.Models.DataContexts
{
    public class BigOnDbContext : DbContext
    {
        public BigOnDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductCatalogItem> ProductCatalog { get; set; }
        public DbSet<Faq> Faqs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductCatalogItem>(cfg =>
            {
                cfg.HasKey(k => new {k.ProductId, k.ProductColorId, k.ProductMaterialId, k.ProductSizeId, k.ProductTypeId});
                cfg.Property(p=>p.Id).UseIdentityColumn(1,1);
            });
        }
    }
}
