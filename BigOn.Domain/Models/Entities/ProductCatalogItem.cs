using BigOn.Domain.AppCode.Infrastructure;

namespace BigOn.Domain.Models.Entities
{
    public class ProductCatalogItem : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product{ get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public int ProductColorId { get; set; }
        public ProductColor ProductColor { get; set; }

        public int ProductSizeId { get; set; }
        public ProductSize ProductSize { get; set; }

        public int ProductMaterialId { get; set; }
        public ProductMaterial ProductMaterial { get; set; }
    }
}
