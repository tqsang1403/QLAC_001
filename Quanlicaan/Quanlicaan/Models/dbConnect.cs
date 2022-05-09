using Quanlicaan.Models.ModelADO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
{
    public class dbConnect
    {
        string connectionString = @"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True";
        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");

        public dbConnect()
        {
            conn.Open();
            command.Connection = conn;
            
        }

        public int Get_IDPhongBan_ById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Int32 IDPhongBan = 0;
                string sql = "SELECT IDPhongBan from NhanVien where ID = @ID";
                SqlCommand com = new SqlCommand(sql, conn);
                com.Parameters.Add("@ID", SqlDbType.Int);
                com.Parameters["@ID"].Value = id;

                try
                {
                    conn.Open();
                    IDPhongBan = (Int32)com.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return (int)IDPhongBan;
            }
        }

        public DataSet Get_Employee_By_IDPhongBan(int IDPhongBan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand("Sp_Get_Employee_By_IDPhongBan", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                com.Parameters.AddWithValue("@IDPhongBan", IDPhongBan);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }


        public void RegistGroupMeal(DangkyantaptheModel model)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand("Sp_Dangkyannhom", conn);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@HoTen", model.HoTenNDK);
                com.Parameters.AddWithValue("@PhongBan", model.PhongBan);
                com.Parameters.AddWithValue("@ngayDK", model.ngayDK);
                com.Parameters.AddWithValue("@SLCa1", model.SLCa1);
                com.Parameters.AddWithValue("@SLCa2", model.SLCa2);
                com.Parameters.AddWithValue("@SLCa3", model.SLCa3);

                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<NhanVienModel> Listnv(string name)
        {

            if (!string.IsNullOrEmpty(name))
            {
                command.CommandText = "Select * from NhanVien where HoTen Like N'%" + name + "%' ";

            }
            else
            {
                command.CommandText = "Select * from NhanVien";
            }

            SqlDataReader reader = command.ExecuteReader();
            List<NhanVienModel> listnv = new List<NhanVienModel>();

            while (reader.Read())
            {
                NhanVienModel employ = new NhanVienModel();
                employ.ID = Convert.ToInt32(reader["ID"]);
                employ.HoTen = reader["HoTen"].ToString();
                employ.GioiTinh = Convert.ToBoolean(reader["GioiTinh"].ToString());
                employ.DiaChi = reader["DiaChi"].ToString();
                employ.SDT = reader["SDT"].ToString();
                employ.IDPhongBan = Convert.ToInt32(reader["IDPhongBan"].ToString());
                employ.ChucVu = reader["ChucVu"].ToString();
                employ.IDrole = Convert.ToInt32(reader["IDRole"]);
                employ.username = reader["username"].ToString();
                employ.upassword = reader["upassword"].ToString();
                employ.trangthai = Convert.ToBoolean(reader["trangthai"]);
                employ.RoleRegist = reader["RoleRegist"].ToString();

                listnv.Add(employ);
            }
            conn.Close();
            return listnv;
        }


        


        //public DataSet getAllRoler()
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        Roles pb = new Roles();
        //        command.CommandText = "Select * from Roles";
        //        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        //        dataAdapter.SelectCommand = command;
        //        DataSet dataSet = new DataSet();
        //        dataAdapter.Fill(dataSet, "Roles");

        //        conn.Close();
        //        return dataSet;
        //    }

        //}

    }
}