using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.DAO
{

    public class PhongbanModel
    { 
        public SqlConnection conn = ConnectDb.ConnectionDb();
        public SqlCommand command = new SqlCommand();

        public PhongbanModel()
        {
            conn.Open();
            command.Connection = conn;

        }

        public DataSet getAllPhongBan()
        {
            command.CommandText = "Select * from PhongBan";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet,"PhongBan");
            
            conn.Close();
            return dataSet;
            
        }

    }
}