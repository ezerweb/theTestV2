using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theTestV2.Models
{
    public class TestOrderProducts
    {
        public int id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}