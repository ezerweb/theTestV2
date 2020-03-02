using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theTestV2.Models
{
    public class TestOrders
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}