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
            dataAdapter.Fill(dataSet, "PhongBan");

            conn.Close();
            return dataSet;
        }

        public PhongBan getAllPhongBan(int ID)
        {
            command.CommandText = "Select * from PhongBan where ID ="+ID;
            SqlDataReader dr = command.ExecuteReader();
            PhongBan phongban = new PhongBan();
            while (dr.Read())
            {
                phongban.ID =  Convert.ToInt32( dr["ID"]);
                phongban.TenPB = dr["TenPB"].ToString();
            }

            conn.Close();
            return phongban;
        }

        public void addPhongBan(string namePhongBan)
        {
            command.CommandText = "insert into PhongBan(TenPB) values (N'" + namePhongBan + "')";
            command.ExecuteNonQuery();
            conn.Close();
        }


        public void updatePhongBan( string TenPb , int ID)
        {
            command.CommandText = "Update  PhongBan set TenPB = @Tenpb where ID=@idpb";
            command.Parameters.AddWithValue("@Tenpb", TenPb);
            command.Parameters.AddWithValue("@idpb", ID);
            command.ExecuteNonQuery();

            conn.Close();
        }


    }
}