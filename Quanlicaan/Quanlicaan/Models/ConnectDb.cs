using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
{
    public class ConnectDb
    {
        public static SqlConnection ConnectionDb()
        {
           var connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder["Server"] = @"TOANLV\SQLEXPRESS";
            connectionStringBuilder["Initial Catalog"] = "QuanLiCaAn";
            connectionStringBuilder["User ID"] = "sa";
            connectionStringBuilder["Password"] = "123456";

            string connectionString = connectionStringBuilder.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }


    }
}