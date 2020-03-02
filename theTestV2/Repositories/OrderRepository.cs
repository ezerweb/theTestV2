using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using theTestV2.Models;

namespace theTestV2.Repositories
{
    public class OrderRepository : DBConnection
    {
        public List<OrderModel> GetOrders()
        {
            List<OrderModel> Orders = new List<OrderModel>();

            this.getDBConnection();

            myConn.Open();
            myCmd = new SqlCommand("sp_GetOrders", myConn);
            myCmd.CommandType = CommandType.StoredProcedure;

            myReader = myCmd.ExecuteReader();

            if (myReader.HasRows)
            {
                while (myReader.Read())
                {   
                    OrderModel orderModel = new OrderModel();

                    orderModel.OrderId = (int)myReader["OrderId"];
                    orderModel.FirstName = (string)myReader["FirstName"];
                    orderModel.LastName = (string)myReader["LastName"];
                    orderModel.Address = (string)myReader["Address"];
                    orderModel.City = (string)myReader["City"];
                    orderModel.State = (string)myReader["State"];
                    orderModel.Country = (string)myReader["Country"];

                    Orders.Add(orderModel);                    

                }
            }

            return Orders;
        }
    }
}