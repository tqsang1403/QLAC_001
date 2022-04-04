using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Quanlicaan.Models
{


    public class UserModel
    {

       // private Model1 context1 = null;
        public  SqlConnection conn = ConnectDb.ConnectionDb();
        public UserModel()
        {
            conn.Open();
           // context1 = new Model1();

        }

        /*
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
        */
        public  List<NhanVien> Listnv(  )
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
            conn.Close();
            return listnv;
        }
        

        public NhanVien ListnvUpdate(int id)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "Select * from NhanVien where ID = @ID";
            
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@ID";
            param.Value = id;

            command.Parameters.Add(param);
            SqlDataReader reader = command.ExecuteReader();
            NhanVien employ = new NhanVien();
            reader.Read();
                
            employ.ID = Convert.ToInt32(reader["ID"]);
            employ.HoTen = reader["HoTen"].ToString();
            employ.GioiTinh = Convert.ToBoolean(reader["GioiTinh"].ToString());
            employ.DiaChi = reader["DiaChi"].ToString();
            employ.SDT = reader["SDT"].ToString();
            employ.IDPhongBan = Convert.ToInt32(reader["IDPhongBan"].ToString());
            employ.ChucVu = reader["ChucVu"].ToString();
            employ.username = reader["username"].ToString();
            employ.upassword = reader["upassword"].ToString();
            employ.trangthai = Convert.ToBoolean(reader["trangthai"]);
            
            conn.Close();
            return employ;
        }

        public void UpdateNv(NhanVien nhanvien )
        {
           
            
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "Update NhanVien Set HoTen =@hoten , GioiTinh = @Gioitinh , DiaChi = @Diachi, SDT = @sdt , IDPhongBan = @idpb, ChucVu =@ChucVu, username = @username, upassword = @pass, trangthai=@trangthai where ID = @ID";
                command.Parameters.AddWithValue("@ID", nhanvien.ID);
                command.Parameters.AddWithValue("@hoten", nhanvien.HoTen);
                command.Parameters.AddWithValue("@Gioitinh", nhanvien.GioiTinh);
                command.Parameters.AddWithValue("@Diachi", nhanvien.DiaChi);
                command.Parameters.AddWithValue("@sdt", nhanvien.SDT);
                command.Parameters.AddWithValue("@idpb", nhanvien.IDPhongBan);
                command.Parameters.AddWithValue("@ChucVu", nhanvien.ChucVu);
                command.Parameters.AddWithValue("@username", nhanvien.username);
                command.Parameters.AddWithValue("@pass", nhanvien.upassword);
                command.Parameters.AddWithValue("@trangthai", nhanvien.trangthai);

                command.ExecuteNonQuery();
                conn.Close();
             

            
           
           
        }
        
    }
}