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

        public CaAnModel()
        {

        }

        // lấy danh sách ca ăn người dùng đã đăng kí 
        public List<CaAn> GetCaAns(int ID)
        {
            conn.Open();
            command.Connection = conn;
            List<CaAn> list = new List<CaAn>();
            command.CommandText = "select CaAn.*, ChiTietSuatAn.Soluong from ChiTietSuatAn inner join CaAn on ChiTietSuatAn.IDCaan = CaAn.ID  where IDUser = @iduser and  ChiTietSuatAn.Thoigiandat between CONVERT(datetime, CONVERT(date, GETDATE())) and CONVERT(datetime, CONVERT(date, dateadd(day,1,GETDATE())))";
            command.Parameters.AddWithValue("@iduser", ID);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {

                    CaAn ca = new CaAn();
                    ca.ID = Convert.ToInt32(dr["ID"]);
                    ca.Thoigian = Convert.ToDateTime(dr["Thoigian"]);
                   
                    list.Add(ca);


                }
                //if (list.Count == 1)
                //{
                //    if (list[0].ID == 1)
                //    {
                //        for (int i = 2; i <= 3; i++)
                //        {
                //            CaAn ca = new CaAn();
                //            ca.ID = i;
                //            ca.Thoigian = Convert.ToDateTime("(2022 - 03 - 02 15:00:00.000");
                //            ca.IsChecked = false;
                //            ca.SoluongSuatan = 0;
                //            list.Add(ca);
                //        }

                //    }
                //    else if (list[0].ID == 2)
                //    {
                //        for (int i = 1; i <= 3; i += 2)
                //        {
                //            CaAn ca = new CaAn();
                //            ca.ID = i;
                //            ca.Thoigian = Convert.ToDateTime("(2022 - 03 - 02 15:00:00.000");
                //            ca.IsChecked = false;
                //            ca.SoluongSuatan = 0;
                //            list.Add(ca);
                //        }

                //    }
                //    else
                //    {
                //        for (int i = 2; i <= 3; i++)
                //        {
                //            CaAn ca = new CaAn();
                //            ca.ID = i;
                //            ca.Thoigian = Convert.ToDateTime("(2022 - 03 - 02 15:00:00.000");
                //            ca.IsChecked = false;
                //            ca.SoluongSuatan = 0;
                //            list.Add(ca);
                //        }
                //    }

                //}
            }
            else
            {
                dr.Close();
                command.CommandText = "select * from CaAn";
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    CaAn ca = new CaAn();
                    ca.ID = Convert.ToInt32(dr["ID"]);
                    ca.Thoigian = Convert.ToDateTime(dr["Thoigian"]);
                   
                    list.Add(ca);
                }
            }
            command.Parameters.Clear();
            conn.Close();

            return list;
        }


        //lấy  danh sách ca ăn
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
                list.Add(ca);
            }
            conn.Close();

            return list;
        }

    }
}