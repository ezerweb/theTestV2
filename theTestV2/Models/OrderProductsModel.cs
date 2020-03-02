using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theTestV2.Models
{
    public class OrderProductsModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public string CategoryName { get; set; }
    }
}