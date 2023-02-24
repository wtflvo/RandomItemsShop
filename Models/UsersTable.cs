using System;
using System.Collections.Generic;

namespace RandomItemsShop.Models
{
    public partial class UsersTable
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
