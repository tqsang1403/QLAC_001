using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.DAO
{
    public class RolerModel
    {
        public SqlConnection conn = ConnectDb.ConnectionDb();
        public SqlCommand command = new SqlCommand();


        public RolerModel()
        {
            conn.Open();
            command.Connection = conn;

        }

        public DataSet getAllRoler()
        {
            Role pb = new Role();
            command.CommandText = "Select * from Roles";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Role");

            conn.Close();
            return dataSet;

        }
    }
}