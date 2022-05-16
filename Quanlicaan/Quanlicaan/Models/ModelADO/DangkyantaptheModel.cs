using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class DangkyantaptheModel
    {
        dbConnect dbLayer = new dbConnect();
        public string HoTen { get; set; }

        public int IDUser { get; set; }
        public string PhongBan { get; set; }
        public DateTime ngayDK { get; set; }
        public int SLCa1 { get; set; }

        public int SLCa2 { get; set; }

        public int SLCa3 { get; set; }

        public bool TrangThai { get; set; }
        public List<CaAn> ListCaAn { get; set; }
        public DangkyantaptheModel()
        {
        }

        SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");
        public SqlCommand command = new SqlCommand();
        public SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public DataSet ds = new DataSet();
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