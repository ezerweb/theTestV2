using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using theTestV2.Models;

namespace theTestV2.Controllers
{
    public class OrdersController : ApiController
    {
        public string Post(ShipmentModel shipment)
        {
            string rtnMsg = "";
            string jsonString = "";

            rtnMsg += " # Request Body # " + "\n";

            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss = new JavaScriptSerializer();

            StringBuilder sb = new StringBuilder();
            jss.Serialize(shipment, sb);
            jsonString = sb.ToString();

            rtnMsg += JValue.Parse(jsonString).ToString(Formatting.Indented);

            return rtnMsg;

        }
    }
}
