using BigOn.Domain.AppCode.Infrastructure;
using System.Collections.Generic;

namespace BigOn.Domain.Models.Entities
{
    public class ProductColor : BaseEntity
    {
        public string Name { get; set; }
        public string Hex { get; set; }
        public ICollection<ProductCatalogItem> ProductCatalog { get; set; }

    }
}
