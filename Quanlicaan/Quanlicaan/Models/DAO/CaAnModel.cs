using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.DAO
{
    public class CaAnModel
    {
        public SqlConnection conn = ConnectDb.ConnectionDb();
        public SqlCommand command = new SqlCommand();
        public SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public DataSet ds = new DataSet();

        public CaAnModel() {
           
        }

        public List<CaAn> GetCaAns()
        {
            conn.Open();
            command.Connection = conn;
            List<CaAn> list = new List<CaAn>();
            command.CommandText = "select * from CaAn";
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                CaAn ca = new CaAn();
                ca.ID = Convert.ToInt32(dr["ID"]);
                ca.Thoigian = Convert.ToDateTime(dr["Thoigian"]);
                ca.IsChecked = false;
                ca.SoluongSuatan = 0;
                list.Add(ca);
            }
            conn.Close();

            return list;
        }

    }
}