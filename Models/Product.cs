
using System;
using System.Collections.Generic;

namespace DMART.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; } = null!;
        public string CategoryId { get; set; } = null!;
        public int Discount { get; set; }
        public int DiscountPercentage { get; set; }
        
    }
}
