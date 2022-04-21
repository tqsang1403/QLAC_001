using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
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

        public void getAllPhongBan()
        {
            List<PhongBan> list = new List<PhongBan>();
            PhongBan pb = new PhongBan();
            command.CommandText = "Select * form PhongBan";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.TableMappings.Add("Table", "Phongban");
            dataAdapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            
            
        }

    }
}