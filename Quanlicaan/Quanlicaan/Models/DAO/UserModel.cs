using Quanlicaan.Models.Framework;
using Quanlicaan.Models.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.DAO
{


    public class UserModel
    {
        public SqlConnection conn = ConnectDb.ConnectionDb();
        public SqlCommand command = new SqlCommand();

        public UserModel()
        {
            conn.Open();
            command.Connection = conn;

        }

        // thêm mới 1 nhân viên
        public bool AddNv(NhanVien nhanvien)
        {
            if (nhanvien != null)
            {
                command.CommandText = "insert into NhanVien(HoTen, GioiTinh , DiaChi,SDT , IDPhongBan , ChucVu ,IDRole, username , upassword , trangthai) values(@Hoten , @gioitinh , @Diachi, @SDT ,@IdPb ,@Chucvu ,@IdRole,@username ,@pass ,@trangthai)";

                command.Parameters.AddWithValue("@Hoten", nhanvien.HoTen);
                command.Parameters.AddWithValue("@gioitinh", nhanvien.GioiTinh);
                command.Parameters.AddWithValue("@Diachi", nhanvien.DiaChi);
                command.Parameters.AddWithValue("@SDT", nhanvien.SDT);
                command.Parameters.AddWithValue("@IdPb", nhanvien.IDPhongBan);
                command.Parameters.AddWithValue("@Chucvu", nhanvien.ChucVu);
                command.Parameters.AddWithValue("@IdRole", nhanvien.IDrole);
                command.Parameters.AddWithValue("@username", nhanvien.username);
                command.Parameters.AddWithValue("@pass", nhanvien.upassword);
                command.Parameters.AddWithValue("@trangthai", nhanvien.trangthai);

                command.ExecuteNonQuery();


                conn.Close();
                return true;
            }
            else
            {
                return false;
            }

        }


        // tìm kiếm nhân viên theo tên
        public List<NhanVien> Listnv(string name)
        {

            if (!string.IsNullOrEmpty(name))
            {
                command.CommandText = "Select * from NhanVien where HoTen Like N'%" + name + "%' ";
                /*  command.CommandText = "Select * from NhanVien where HoTen Like N'%@Hoten%' ";

                  SqlParameter param = new SqlParameter();
                  param.ParameterName = "@Hoten";
                  param.Value = name;
                  command.Parameters.Add(param);
                  */

            }
            else
            {
                command.CommandText = "Select * from NhanVien";
            }

            SqlDataReader reader = command.ExecuteReader();
            List<NhanVien> listnv = new List<NhanVien>();

            while (reader.Read())
            {
                NhanVien employ = new NhanVien();
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

                listnv.Add(employ);
            }
            conn.Close();
            return listnv;
        }

        // trả về nhân viên cần update
        public NhanVien ListnvUpdate(int id)
        {
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
            employ.IDrole = Convert.ToInt32(reader["IDRole"]);
            employ.username = reader["username"].ToString();
            employ.upassword = reader["upassword"].ToString();
            employ.trangthai = Convert.ToBoolean(reader["trangthai"]);

            conn.Close();
            return employ;
        }

        // thực hiện update
        public void UpdateNv(NhanVien nhanvien)
        {
            command.CommandText = "Update NhanVien Set HoTen =@hoten , GioiTinh = @Gioitinh , DiaChi = @Diachi, SDT = @sdt , IDPhongBan = @idpb, ChucVu =@ChucVu,IDRole = @idRole ,username = @username, upassword = @pass, trangthai=@trangthai where ID = @ID";
            command.Parameters.AddWithValue("@ID", nhanvien.ID);
            command.Parameters.AddWithValue("@hoten", nhanvien.HoTen);
            command.Parameters.AddWithValue("@Gioitinh", nhanvien.GioiTinh);
            command.Parameters.AddWithValue("@Diachi", nhanvien.DiaChi);
            command.Parameters.AddWithValue("@sdt", nhanvien.SDT);
            command.Parameters.AddWithValue("@idpb", nhanvien.IDPhongBan);
            command.Parameters.AddWithValue("@ChucVu", nhanvien.ChucVu);
            command.Parameters.AddWithValue("@idRole", nhanvien.IDrole);
            command.Parameters.AddWithValue("@username", nhanvien.username);
            command.Parameters.AddWithValue("@pass", nhanvien.upassword);
            command.Parameters.AddWithValue("@trangthai", nhanvien.trangthai);

            command.ExecuteNonQuery();
            conn.Close();

        }

        // thực hiện xóa nhân viên
        public void DeleteNv(int id)
        {
            command.CommandText = "Update NhanVien Set trangthai = '"+false+"' where ID ="+id+"";

            string sql = command.CommandText;
            command.ExecuteNonQuery();
            conn.Close();
        }
        
        // thực hiện đăng nhập cho nhân viên
        public UserSession  GetNhanVienLogin(LoginModel login)
        {
           
            UserSession us = new UserSession();

            command.CommandText = "Select * from NhanVien inner join PhongBan on NhanVien.IDPhongBan = PhongBan.ID where username = @username and upassword = @pass";
            command.Parameters.AddWithValue("@username", login.username);
            command.Parameters.AddWithValue("@pass", login.upassword);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    us.hoTen = reader["HoTen"].ToString();
                    us.UserID = Convert.ToInt32(reader["ID"]);
                    us.IdPhongBan = Convert.ToInt32(reader["IDPhongBan"]);
                    us.TenPhongBan = reader["TenPB"].ToString();
                    us.IDRoleUser = Convert.ToInt32(reader["IDRole"]);
                }
                conn.Close();
                return us;
            }
            else
            {
                return us = null;
            }    
               
            
        }

    }
}