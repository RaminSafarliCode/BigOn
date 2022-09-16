using BigOn.WebUI.AppCode.Infrastructure;
using System.Collections.Generic;

namespace BigOn.WebUI.Models.Entities
{
    public class ProductColor : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Colors { get; set; }
    }
}
