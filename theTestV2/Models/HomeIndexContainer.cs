using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theTestV2.Models
{
    public class HomeIndexContainer
    {
        public List<OrderModel> Orders { get; set; }

        public List<ShipmentModel> Shipments { get; set; }

    }
}