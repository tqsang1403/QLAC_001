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

    }
}