using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Quanlicaan.Models
{


    public class UserModel
    {

        private Model1 context1 = null;
        public  SqlConnection conn = ConnectDb.ConnectionDb();
        public UserModel()
        {
            conn.Open();
            context1 = new Model1();

        }


        public int Create(String name, bool Gioitinh, String Diachi, String SDT, int IDPhongBan, String ChucVu, String username, String passsword, bool? trangthai)
        {
            object[] parameters =
            {
                new SqlParameter("@Hoten", name),
                new SqlParameter("@Gioitinh", Gioitinh),
                new SqlParameter("@Diachi", Diachi),
                new SqlParameter("@SDT", SDT),
                new SqlParameter("@IDPhongBan", IDPhongBan),
                new SqlParameter("@ChucVu", ChucVu),

                new SqlParameter("@username", username),
                new SqlParameter("@upassword", passsword),

                new SqlParameter("@trangthai", trangthai)
            };
            int res = context1.Database.ExecuteSqlCommand("spInsertUser @HoTen, @GioiTinh,	@DiaChi  ,	@SDT,	@IDPhongBan ,	@ChucVu ,	@username,	@upassword ,	@trangthai )", parameters);
            return res;

        }

        public  List<NhanVien> Listnv()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "Select * from NhanVien";
            SqlDataReader reader = command.ExecuteReader();
            List<NhanVien> listnv = new List<NhanVien>();
            while (reader.Read())
            {
                NhanVien employ = new NhanVien();
                employ.ID = Convert.ToInt32( reader["ID"]);
                employ.HoTen = reader["HoTen"].ToString();
                employ.GioiTinh = Convert.ToBoolean(reader["GioiTinh"].ToString());
                employ.DiaChi = reader["DiaChi"].ToString();
                employ.SDT = reader["SDT"].ToString();
                employ.IDPhongBan = Convert.ToInt32(reader["IDPhongBan"].ToString());
                employ.ChucVu = reader["ChucVu"].ToString();
                employ.username = reader["username"].ToString();
                employ.upassword = reader["upassword"].ToString();
                employ.trangthai = Convert.ToBoolean(reader["trangthai"]);

                listnv.Add(employ);
            }

            return listnv;
        }
    }
}