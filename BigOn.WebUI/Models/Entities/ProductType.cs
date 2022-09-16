using BigOn.WebUI.AppCode.Infrastructure;
using System.Collections.Generic;

namespace BigOn.WebUI.Models.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Types { get; set; }

    }
}
