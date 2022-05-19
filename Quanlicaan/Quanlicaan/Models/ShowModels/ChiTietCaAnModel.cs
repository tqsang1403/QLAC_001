using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ShowModels
{
    public class ChiTietCaAnModel
    {
        public int ID { get; set; }

        public int IDCaAn { get; set; }
        public int IDUSer { get; set; }
        public int IDSuatAn { get; set; }

        public string TenCaAn { get; set; }
        public int Soluong { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
        public DateTime NgayDk { get; set; }

        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");
        public SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        //right join CaAn on ChiTietSuatAn.IDCaan = CaAn.ID
        public DataSet getPersionalMeal (int IDnv)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select NhanVien.HoTen , SuatAn.Thoigiandat,ChiTietSuatAn.*, CaAn.TenCa from NhanVien inner join SuatAn on NhanVien.ID = SuatAn.IDUser full join ChiTietSuatAn on SuatAn.ID = ChiTietSuatAn.IDSuatAn right join CaAn on ChiTietSuatAn.IDCaan = CaAn.ID where NhanVien.ID = @IDnv and ChiTietSuatAn.Soluong >0";
            command.Parameters.AddWithValue("@IDnv", IDnv);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds,"Baocaocanhan");
            command.Parameters.Clear();
            conn.Close();
            return ds;
        }
        
        
        public DataSet TodayRegist (int IDNV)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "Select ct.*, sa.Thoigiandat, nv.* from ChiTietSuatAn ct join SuatAn sa on ct.IDSuatAn = sa.ID join NhanVien nv on sa.IDUser = nv.ID where ct.Soluong > 0 and(convert(varchar(10), sa.Thoigiandat, 101)) = (SElect DATEADD(DAY, 0, CAST(GETDATE() AS date))) and nv.ID = @IDNV";
            command.Parameters.AddWithValue("@IDNV", IDNV);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds,"CTtoday");
            command.Parameters.Clear();
            conn.Close();
            return ds;
        }


    }
}