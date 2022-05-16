using Quanlicaan.Models.Framework;
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
    public class SuatAnModel
    {
        public SqlConnection conn = ConnectDb.ConnectionDb();
        public SqlCommand command = new SqlCommand();
        public SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public int IDSuatAn;


        public SuatAnModel()
        {
        }

        // thêm 1 bản ghi mới trong bảng suất ăn giá trị trả về là true hoặc false để biết thêm thành công hay không
        public bool InsertSuatAn(int ID, string time)
        {
            conn.Open();
            command.Connection = conn;
            // insert vào bảng suất ăn
            command.CommandText = "insert into SuatAn(IDUser , Thoigiandat) values (@iduser, @time)";
            command.Parameters.AddWithValue("@iduser", ID);
            command.Parameters.AddWithValue("@time", time);
            var check = command.ExecuteNonQuery();
            command.Parameters.Clear();
            conn.Close();
            if (check > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // thêm mới bản ghi bảng chi tiết suất ăn
        public void InsertCTSuatAn(int ID, string time, int IDCaan, int Soluong)
        {
            conn.Open();
            command.Connection = conn;
            //lấy idsuatan vừa đăng kí
            command.CommandText = "select ID from SuatAn where IDUser= @iduser and Thoigiandat= @time";
            command.Parameters.AddWithValue("@time", time);
            command.Parameters.AddWithValue("@iduser", ID);
            var sql = command.CommandText;
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                IDSuatAn = Convert.ToInt32(dr["ID"]);
            }
            dr.Close();
            command.CommandText = "insert into ChiTietSuatAn(IDUser ,Soluong,IDSuatAn,IDCaan, Thoigiandat , Trangthai) values (@iduser, @soluong , @idsuatan , @idcaan, @time, 1)";
            command.Parameters.AddWithValue("@soluong", Soluong);
            command.Parameters.AddWithValue("@idsuatan", IDSuatAn);
            command.Parameters.AddWithValue("@idcaan", IDCaan);

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


        // thực hiện chỉnh sửa thông tin đăng kí ca ăn
        public List<EdiDkiCaAn> getAllSuatAnDangKi(int IDPb)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select ChiTietSuatAn.*, NhanVien.HoTen from ChiTietSuatAn join NhanVien on ChiTietSuatAn.IDUser = NhanVien.ID where IDPhongBan = @idphongban and Thoigiandat between CONVERT(datetime, CONVERT(date, GETDATE())) and CONVERT(datetime, CONVERT(date, dateadd(day,1,GETDATE()))) ";
            command.Parameters.AddWithValue("@idphongban", IDPb);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds, "DsCtSuatAnDki");
            command.Parameters.Clear();
            conn.Close();

            List<EdiDkiCaAn> list = new List<EdiDkiCaAn>();
            foreach (DataRow dr in ds.Tables["DsCtSuatAnDki"].Rows)
            {
                EdiDkiCaAn ediDkiCaAn = new EdiDkiCaAn();
                ediDkiCaAn.IDUser = Convert.ToInt32(dr["IDUser"]);
                ediDkiCaAn.hoTen = dr["HoTen"].ToString();
                ediDkiCaAn.ngayDK = Convert.ToDateTime(dr["Thoigiandat"]);
                ediDkiCaAn.IDCaAn = Convert.ToInt32(dr["IDCaan"]);
                ediDkiCaAn.IDSuatAn = Convert.ToInt32(dr["IDSuatAn"]);
                ediDkiCaAn.Soluong = Convert.ToInt32(dr["Soluong"]);
                list.Add(ediDkiCaAn);
            }
            return list;

        }

    }
}