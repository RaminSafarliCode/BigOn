using BigOn.WebUI.AppCode.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BigOn.WebUI.Models.Entities
{
    public class ProductSize : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string SmallName { get; set; }
        public ICollection<ProductCatalogItem> ProductCatalog { get; set; }

    }
}
