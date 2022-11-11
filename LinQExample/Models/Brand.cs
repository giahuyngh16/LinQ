using System;
using System.Collections.Generic;

namespace LinQExample.Models
{
    public partial class Brand
    {
        public Brand()
        {
            ProductTypes = new HashSet<ProductType>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
}
