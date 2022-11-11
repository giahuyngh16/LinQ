using System;
using System.Collections.Generic;

namespace LinQExample.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public int Size { get; set; }
        public int IdProductDetail { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatorUserId { get; set; }

        public virtual ProductDetail IdProductDetailNavigation { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
