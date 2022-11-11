using System;
using System.Collections.Generic;

namespace LinQExample.Models
{
    public partial class Customer
    {
        public Customer()
        {
            FavoriteProducts = new HashSet<FavoriteProduct>();
            Orders = new HashSet<Order>();
            ReviewDetails = new HashSet<ReviewDetail>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public int TypeAcc { get; set; }
        public bool IsDeleted { get; set; }
        public string? Avatar { get; set; }

        public virtual ICollection<FavoriteProduct> FavoriteProducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ReviewDetail> ReviewDetails { get; set; }
    }
}
