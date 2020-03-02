using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theTestV2.Models
{
    public class ShipmentModel
    {
        public string OrderIds { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<ProductModel> Products { get; set; }
    }

    public partial class ProductModel
    {
        public int CategoryId { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
    }
}