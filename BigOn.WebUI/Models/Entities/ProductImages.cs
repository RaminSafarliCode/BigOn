using BigOn.WebUI.AppCode.Infrastructure;
using System.Collections.Generic;

namespace BigOn.WebUI.Models.Entities
{
    public class ProductImages : BaseEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
