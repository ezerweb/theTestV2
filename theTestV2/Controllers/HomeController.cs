using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using theTestV2.Models;
using theTestV2.Repositories;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace theTestV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeIndexContainer hic = new HomeIndexContainer();
            hic.Orders = new List<OrderModel>();
            hic.Shipments = new List<ShipmentModel>();

            OrderRepository  or = new OrderRepository();
            hic.Orders = or.GetOrders();

            ViewBag.Title = "Orders & Shipments";

            return View(hic);
        }

        [HttpPost]
        public ActionResult shipment(ParamModel param)
        {
            List<ShipmentModel> shipments = new List<ShipmentModel>();

            ShipmentRepository sr = new ShipmentRepository();
            shipments = sr.GetShipments(param.OrderIds);

            return PartialView("/Views/Partials/_PartialShipments.cshtml", shipments);
        }
    }
}
