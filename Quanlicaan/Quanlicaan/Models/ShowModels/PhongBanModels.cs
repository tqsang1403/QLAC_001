
using Quanlicaan.Models.ModelADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Quanlicaan.Models.Models._2
{
    public class PhongBanModels
    {
       

        public SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");

        public SqlCommand command = new SqlCommand();

        public PhongBanModels()
        {
            conn.Open();
            command.Connection = conn;

        }


        public DataSet getAllPhongBan()
        {
            PhongBanModel pb = new PhongBanModel();
            command.CommandText = "Select * from PhongBan";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "PhongBan");

            conn.Close();
            return dataSet;

        }

    }
}