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


        // Images
        public ICollection<ProductImages> Images { get; set; }
        public ICollection<ProductCatalogItem> ProductCatalog { get; set; }

    }
}
