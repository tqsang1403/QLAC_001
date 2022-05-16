using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class SuatAnModels
    {

        public int ID { get; set; }

        public int? IDUser { get; set; }

        public DateTime Thoigiandat { get; set; }

        SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");


        public SqlCommand command = new SqlCommand();

        public SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public DataSet ds = new DataSet();

        public bool InsertSuatAn(int ID, DateTime time)
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
        int IDSuatAn;
        public void InsertCTSuatAn(int ID, DateTime time, int IDCaan, int Soluong)
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
            command.CommandText = "insert into ChiTietSuatAn(IDUser ,Soluong,IDSuatAn,IDCaan) values (@iduser, @soluong , @idsuatan , @idcaan)";
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
    }
}