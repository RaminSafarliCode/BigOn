using BigOn.WebUI.AppCode.Infrastructure;
using System.Collections;
using System.Collections.Generic;

namespace BigOn.WebUI.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        // Foreign Keys
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int ColorId { get; set; }
        public ProductColor ProductColor { get; set; }

        public int SizeId { get; set; }
        public ProductSize ProductSize { get; set; }

        public int MaterialId { get; set; }
        public ProductMaterial ProductMaterial { get; set; }

        public int TypeId { get; set; }
        public ProductType ProductType { get; set; }

    }
}
