using BigOn.WebUI.AppCode.Infrastructure;
using System.Collections.Generic;

namespace BigOn.WebUI.Models.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Brands { get; set; }
    }
}
