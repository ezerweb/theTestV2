using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using theTestV2.Models;

namespace theTestV2.Repositories
{
    public class OrderProductsRepository : DBConnection
    {
        public List<OrderProductsModel> GetOrderProducts(int ParOrderId)
        {
            List<OrderProductsModel> OrderProducts = new List<OrderProductsModel>();

            this.getDBConnection();

            myConn.Open();
            myCmd = new SqlCommand("sp_GetOrderProducts", myConn);
            myCmd.CommandType = CommandType.StoredProcedure;
            myCmd.Parameters.AddWithValue("ParOrderId", ParOrderId);

            myReader = myCmd.ExecuteReader();

            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    OrderProductsModel op = new OrderProductsModel();

                    op.ProductId = (int)myReader["ProductId"];
                    op.Quantity = (int)myReader["Quantity"];
                    op.ProductName = (string)myReader["ProductName"];
                    op.SKU = (string)myReader["SKU"];
                    op.CategoryName = (string)myReader["CategoryName"];

                    OrderProducts.Add(op);
                }
            }

            return OrderProducts;
        }
    }
}