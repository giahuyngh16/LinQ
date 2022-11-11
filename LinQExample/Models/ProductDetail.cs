using System;
using System.Collections.Generic;

namespace LinQExample.Models
{
    public partial class ProductDetail
    {
        public ProductDetail()
        {
            FavoriteProducts = new HashSet<FavoriteProduct>();
            Products = new HashSet<Product>();
            ReviewDetails = new HashSet<ReviewDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Pic1 { get; set; }
        public string? Pic2 { get; set; }
        public string? Pic3 { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public int IdProductType { get; set; }
        public bool IsDeleted { get; set; }
        public int BasePrice { get; set; }

        public virtual ProductType IdProductTypeNavigation { get; set; } = null!;
        public virtual ICollection<FavoriteProduct> FavoriteProducts { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ReviewDetail> ReviewDetails { get; set; }
    }
}
