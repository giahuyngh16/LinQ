using System;
using System.Collections.Generic;

namespace LinQExample.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int IdBrand { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Brand IdBrandNavigation { get; set; } = null!;
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
