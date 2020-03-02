using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using theTestV2.Models;

namespace theTestV2.Repositories
{
    public class ShipmentRepository : DBConnection
    {
        public List<ShipmentModel> GetShipments(string parOrderIds)
        {
            List<ShipmentModel> Shipments = new List<ShipmentModel>();

            if ( parOrderIds != null)
            {
                this.getDBConnection();

                myConn.Open();

                myCmd = new SqlCommand("sp_GetShipments", myConn);
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.Parameters.AddWithValue("ParOrderIds", parOrderIds);
            
                myReader = myCmd.ExecuteReader();

                if (myReader.HasRows)
                {
                    string currOrderIds = "";
                    int currCategoryId = 0;
                    int currProductCount = 0;

                    while (myReader.Read())
                    {
                        if (currOrderIds != RemoveDuplicates((string)myReader["OrderIds"]) || currCategoryId != (int)myReader["CategoryId"])
                        {
                            currOrderIds = RemoveDuplicates((string)myReader["OrderIds"]);
                            currCategoryId = (int)myReader["CategoryId"];
                            currProductCount = 0;

                            ShipmentModel s = new ShipmentModel();
                            Shipments.Add(s);

                            s.OrderIds = RemoveDuplicates((string)myReader["OrderIds"]);
                            s.FirstName = (string)myReader["FirstName"];
                            s.LastName = (string)myReader["LastName"];
                            s.Address = (string)myReader["Address"];
                            s.City = (string)myReader["City"];
                            s.State = (string)myReader["State"];
                            s.Country = (string)myReader["Country"];
                            s.Products = new List<ProductModel>();
                        }

                        ProductModel pm = new ProductModel();
                        currCategoryId = (int)myReader["CategoryId"];
                        pm.CategoryId = currCategoryId;
                        pm.SKU = (string)myReader["SKU"];
                        pm.Quantity = (int)myReader["Quantity"];
                        

                        if (currProductCount == 0)
                        {
                            Shipments.Find(s => s.OrderIds.Equals(currOrderIds) && s.Products.Count() == 0).Products.Add(pm);
                            currProductCount++;
                        }
                        else
                        {
                            Shipments.Find(s => s.OrderIds.Equals(currOrderIds) && s.Products[0].CategoryId.Equals(currCategoryId)).Products.Add(pm);
                            currProductCount++;
                        };                        
                    }
                }
            }

            return Shipments;
        }

        private string RemoveDuplicates(string input)
        {
            string[] i = input.Split(',');
            string[] o = i.Distinct().ToArray();
            string output = string.Join(",", o);
            return output;
        }

    }
}