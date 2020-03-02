using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace theTestV2.Repositories
{
    public class DBConnection
    {
        protected SqlConnection myConn;
        protected SqlCommand myCmd;
        protected SqlDataReader myReader;

        public virtual void getDBConnection()
        {
            myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
    }
}