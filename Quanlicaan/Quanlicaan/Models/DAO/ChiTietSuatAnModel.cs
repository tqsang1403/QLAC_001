
using Quanlicaan.Models.ModelsPage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.DAO
{
    public class ChiTietSuatAnModel
    {
        public SqlConnection conn = ConnectDb.ConnectionDb();
        public SqlCommand command = new SqlCommand();
        public SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public int IDSuatAn;


        public ChiTietSuatAnModel()
        {
        }

        // thêm 1 bản ghi mới trong bảng suất ăn 
        public void InsertSuatAn(int ID, string time, bool loaisuatan)
        {
            conn.Open();
            command.Connection = conn;
            // insert vào bảng suất ăn
            command.CommandText = "insert into SuatAn(IDUser , Thoigiandat, Loaisuatan) values (@iduser, @time , @loaisuatan)";
            command.Parameters.AddWithValue("@iduser", ID);
            command.Parameters.AddWithValue("@time", time);
            command.Parameters.AddWithValue("@loaisuatan", loaisuatan);
            command.ExecuteNonQuery();

            command.Parameters.Clear();
            conn.Close();
          
        }

       

        // thêm mới bản ghi bảng chi tiết suất ăn cho tập thể
        public void InsertCTSuatAn(int ID, int IDUserDangKi, string time, int IDCaan, int Soluong, string tennvcapnhap)
        {
            conn.Open();
            command.Connection = conn;
            //lấy id suat an vừa đăng kí
            command.CommandText = "select ID from SuatAn where IDUser= @iduserdangki and Thoigiandat= @time";
            command.Parameters.AddWithValue("@time", time);
            command.Parameters.AddWithValue("@iduserdangki", IDUserDangKi);
            string sql = command.CommandText;
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                IDSuatAn = Convert.ToInt32(dr["ID"]);
            }
            dr.Close();

            command.CommandText = "insert into ChiTietSuatAn(IDUser ,Soluong,IDSuatAn,IDCaan, Thoigiancapnhat, Tennhanviencapnhat ) values (@iduser, @soluong , @idsuatan , @idcaan, @time, @tennvcapnhat)";
            command.Parameters.AddWithValue("@iduser", ID);
            command.Parameters.AddWithValue("@soluong", Soluong);
            command.Parameters.AddWithValue("@idsuatan", IDSuatAn);
            command.Parameters.AddWithValue("@idcaan", IDCaan);
            command.Parameters.AddWithValue("@tennvcapnhat", tennvcapnhap);
            command.ExecuteNonQuery();
            
            command.Parameters.Clear();
            conn.Close();
        }


        // insert chi tiết suất ăn cho cá nhân
        public void InsertCTSuatAn(int ID, string time, int IDCaan, int Soluong, string tennvcapnhap)
        {
            conn.Open();
            command.Connection = conn;
            //lấy id suat an vừa đăng kí
            command.CommandText = "select ID from SuatAn where IDUser= @iduser and Thoigiandat= @time ";
            command.Parameters.AddWithValue("@time", time);
            command.Parameters.AddWithValue("@iduser", ID);
            string sql = command.CommandText;
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                IDSuatAn = Convert.ToInt32(dr["ID"]);
            }
            dr.Close();

            command.CommandText = "insert into ChiTietSuatAn(IDUser ,Soluong,IDSuatAn,IDCaan, Thoigiancapnhat, Tennhanviencapnhat ) values (@iduser, @soluong , @idsuatan , @idcaan, @time, @tennvcapnhat)";
            command.Parameters.AddWithValue("@soluong", Soluong);
            command.Parameters.AddWithValue("@idsuatan", IDSuatAn);
            command.Parameters.AddWithValue("@idcaan", IDCaan);
            command.Parameters.AddWithValue("@tennvcapnhat", tennvcapnhap);
            command.ExecuteNonQuery();

            command.Parameters.Clear();
            conn.Close();
        }

        ////////// thực hiện thêm suất ăn với tập thể
        public DataSet getAllNhanVienCungPhongBan(int IDPhongBan)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select NhanVien.* , PhongBan.TenPB from  NhanVien inner join PhongBan on NhanVien.IDPhongBan = PhongBan.ID where NhanVien.IDPhongBan = @idphongban ";
            command.Parameters.AddWithValue("@idphongban", IDPhongBan);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds, "DanhSachNvCungPhong");
            command.Parameters.Clear();
            conn.Close();
            return ds;
        }


        ///////// thực hiện chỉnh sửa thông tin đăng kí ca ăn
        // lấy tất cả các chi tiết suất ăn nhân viên đã đăng kí trong ngày  sử dụng cho trang Home
        public List<EdiDkiCaAnModelPage> getAllSuatAnDangKi(int IDPb, int IDUser)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select ChiTietSuatAn.*, NhanVien.HoTen from ChiTietSuatAn join NhanVien on ChiTietSuatAn.IDUser = NhanVien.ID where  IDUser = @iduser and IDPhongBan = @idphongban and Thoigiancapnhat between CONVERT(datetime, CONVERT(date, GETDATE())) and CONVERT(datetime, CONVERT(date, dateadd(day,1,GETDATE()))) ";
            command.Parameters.AddWithValue("@idphongban", IDPb);
            command.Parameters.AddWithValue("@iduser", IDUser);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds, "DsCtSuatAnDki");
            command.Parameters.Clear();
            conn.Close();

            List<EdiDkiCaAnModelPage> list = new List<EdiDkiCaAnModelPage>();
            foreach (DataRow dr in ds.Tables["DsCtSuatAnDki"].Rows)
            {
                EdiDkiCaAnModelPage ediDkiCaAn = new EdiDkiCaAnModelPage();
                ediDkiCaAn.IDUser = Convert.ToInt32(dr["IDUser"]);
                ediDkiCaAn.hoTen = dr["HoTen"].ToString();
                ediDkiCaAn.ngayDK = Convert.ToDateTime(dr["Thoigiancapnhat"]);
                ediDkiCaAn.IDCaAn = Convert.ToInt32(dr["IDCaan"]);
                ediDkiCaAn.IDChiTietSuatAn = Convert.ToInt32(dr["ID"]);
                ediDkiCaAn.IDSuatAn = Convert.ToInt32(dr["IDSuatAn"]);
                ediDkiCaAn.Soluong = Convert.ToInt32(dr["Soluong"]);
                list.Add(ediDkiCaAn);
            }
            return list;

        }


        ///////// thực hiện chỉnh sửa thông tin đăng kí ca ăn
        // lấy 1 mã chi tiết suất ăn trong trang chỉnh sửa thông tin suất ăn
        public List<EdiDkiCaAnModelPage> getAllSuatAnDangKi(int IDPb, int IDUser, int IDCTsuatan)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select ChiTietSuatAn.*, NhanVien.HoTen from ChiTietSuatAn join NhanVien on ChiTietSuatAn.IDUser = NhanVien.ID where ChiTietSuatAn.ID = @idchitietsuatan and  IDUser = @iduser and IDPhongBan = @idphongban and Thoigiancapnhat between CONVERT(datetime, CONVERT(date, GETDATE())) and CONVERT(datetime, CONVERT(date, dateadd(day,1,GETDATE()))) ";
            command.Parameters.AddWithValue("@idchitietsuatan", IDCTsuatan);
            command.Parameters.AddWithValue("@idphongban", IDPb);
            command.Parameters.AddWithValue("@iduser", IDUser);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds, "DsCtSuatAnDki");
            command.Parameters.Clear();
            conn.Close();

            List<EdiDkiCaAnModelPage> list = new List<EdiDkiCaAnModelPage>();
            foreach (DataRow dr in ds.Tables["DsCtSuatAnDki"].Rows)
            {
                EdiDkiCaAnModelPage ediDkiCaAn = new EdiDkiCaAnModelPage();
                ediDkiCaAn.IDUser = Convert.ToInt32(dr["IDUser"]);
                ediDkiCaAn.hoTen = dr["HoTen"].ToString();
                ediDkiCaAn.ngayDK = Convert.ToDateTime(dr["Thoigiancapnhat"]);
                ediDkiCaAn.IDCaAn = Convert.ToInt32(dr["IDCaan"]);
                ediDkiCaAn.IDChiTietSuatAn = Convert.ToInt32(dr["ID"]);
                ediDkiCaAn.IDSuatAn = Convert.ToInt32(dr["IDSuatAn"]);
                ediDkiCaAn.Soluong = Convert.ToInt32(dr["Soluong"]);
                list.Add(ediDkiCaAn);
            }
            return list;

        }



        // thực hiện lấy ra tất cả suất ăn nhân viên  đã đăng kí
        public List<EdiDkiCaAnModelPage> getAllSuatAnDangKi(int IDUser)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select ChiTietSuatAn.* , NhanVien.HoTen from ChiTietSuatAn inner join NhanVien on ChiTietSuatAn.IDUser = NhanVien.ID where IDUser = @idUser";
            command.Parameters.AddWithValue("@idUser", IDUser);

            SqlDataReader dr = command.ExecuteReader();

            command.Parameters.Clear();
            

            List<EdiDkiCaAnModelPage> list = new List<EdiDkiCaAnModelPage>();
           while(dr.Read())
            {
                EdiDkiCaAnModelPage ediDkiCaAn = new EdiDkiCaAnModelPage();
                ediDkiCaAn.IDUser = Convert.ToInt32(dr["IDUser"]);
                ediDkiCaAn.hoTen = dr["HoTen"].ToString();
                ediDkiCaAn.ngayDK = Convert.ToDateTime(dr["Thoigiandat"]);
                ediDkiCaAn.IDCaAn = Convert.ToInt32(dr["IDCaan"]);
                ediDkiCaAn.IDChiTietSuatAn = Convert.ToInt32(dr["ID"]);
                ediDkiCaAn.IDSuatAn = Convert.ToInt32(dr["IDSuatAn"]);
                ediDkiCaAn.Soluong = Convert.ToInt32(dr["Soluong"]);
                list.Add(ediDkiCaAn);
            }

            conn.Close();
            return list;
        }



        //// thực hiện lấy số lượng suất ăn của từng ca ăn của nhân viên đang đăng nhập
        public int getSLSuatAn(int IDUser, int IDCaan )
        {
            int SL=0;
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select Soluong from ChiTietSuatAn where  IDUser=@iduser  and IDCaan =@idcaan and Thoigiancapnhat between CONVERT(datetime, CONVERT(date, GETDATE())) and CONVERT(datetime, CONVERT(date, dateadd(day,1,GETDATE())))";
            command.Parameters.AddWithValue("@iduser", IDUser);
            command.Parameters.AddWithValue("@idcaan", IDCaan);
            SqlDataReader dr =  command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                        SL = Convert.ToInt32(dr["Soluong"]);
                }
            }
            else
            {
                    SL = 0;
            }

            command.Parameters.Clear();
            conn.Close();
            return SL;
        }



        


        ////// thực hiện update dữ liệu mới
        public void UpDateChiTietSuatAn(int idUser , int idChiTietSuatAn , int Soluong , string Thoigiancapnhat , string Nhanviecapnhat)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "update ChiTietSuatAn set Soluong = @soluong, Thoigiancapnhat = @time, Tennhanviencapnhat = @tennhanvien where IDUser = @iduser and ID = @idctsuatan";
            command.Parameters.AddWithValue("@iduser", idUser);
            command.Parameters.AddWithValue("@idctsuatan", idChiTietSuatAn);
            command.Parameters.AddWithValue("@soluong", Soluong);
            command.Parameters.AddWithValue("@time", Thoigiancapnhat);
            command.Parameters.AddWithValue("@tennhanvien", Nhanviecapnhat);

            command.ExecuteNonQuery();
            command.Parameters.Clear();

            
            conn.Close();
        }

        ////// thực hiện xóa chi tiết suất ăn  
        public void DeleteChiTietSuatAn(int IDChiTietSuatAn)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "Delete ChiTietSuatAn  where ID = @idctsuatan";
            command.Parameters.AddWithValue("@idctsuatan", IDChiTietSuatAn);

            command.ExecuteNonQuery();

            command.Parameters.Clear();
            conn.Close();
        }


       

    }
}