using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
{
    public class dbConnect
    {
        public static void Connect()
        {
           SqlConnection conn = new SqlConnection(@"data source=TQS1403\SQLEXPRESS02;initial catalog=QuanLiCaAn;Integrated Security=True");
            
        }

    }
}