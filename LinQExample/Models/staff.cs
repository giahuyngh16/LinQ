using System;
using System.Collections.Generic;

namespace LinQExample.Models
{
    public partial class staff
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public int TypeAcc { get; set; }
        public bool IsDeleted { get; set; }
        public string? Avatar { get; set; }
        public int Salary { get; set; }
    }
}
