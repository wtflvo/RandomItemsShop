using System;
using System.Collections.Generic;

namespace RandomItemsShop.Models
{
    public partial class ShopTable
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int Count { get; set; }
    }
}
