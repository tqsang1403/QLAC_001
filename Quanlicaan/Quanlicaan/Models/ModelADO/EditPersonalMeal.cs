using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class EditPersonalMeal
    {
        public int ID { get; set; }

        public int IDCaAn { get; set; }
        public int IDUSer { get; set; }
        public int IDSuatAn { get; set; }
        public string HoTen { get; set; }
        public string TenCaAn { get; set; }
        public int Soluong { get; set; }

        public int IDChiTietSuatAn { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
        public DateTime NgayDk { get; set; }


        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");
        public SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public DataSet ds = new DataSet();



        public List<EditPersonalMeal> getAllSuatAnDangKi( int IDUser)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select ct.*, nv.HoTen,sa.Thoigiandat from ChiTietSuatAn ct  join NhanVien nv on ct.IDUser = nv.ID join SuatAn sa on ct.IDSuatAn = sa.ID where  ct.IDUser = @iduser and (convert(varchar(10),sa.Thoigiandat , 101)) = (SElect DATEADD(DAY,0, CAST(GETDATE() AS date))) ";
            
            command.Parameters.AddWithValue("@iduser", IDUser);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds, "DsCtSuatAnDki");
            command.Parameters.Clear();
            conn.Close();

            List<EditPersonalMeal> list = new List<EditPersonalMeal>();
            foreach (DataRow dr in ds.Tables["DsCtSuatAnDki"].Rows)
            {
                EditPersonalMeal ediDkiCaAn = new EditPersonalMeal();
                ediDkiCaAn.IDUSer = Convert.ToInt32(dr["IDUser"]);
                ediDkiCaAn.HoTen = Convert.ToString(dr["HoTen"]);
                ediDkiCaAn.NgayDk = Convert.ToDateTime(dr["Thoigiandat"]);
                ediDkiCaAn.IDCaAn = Convert.ToInt32(dr["IDCaan"]);
                ediDkiCaAn.IDChiTietSuatAn = Convert.ToInt32(dr["ID"]);
                ediDkiCaAn.IDSuatAn = Convert.ToInt32(dr["IDSuatAn"]);
                ediDkiCaAn.Soluong = Convert.ToInt32(dr["Soluong"]);
                list.Add(ediDkiCaAn);
            }
            return list;

        }


        public void UpDateChiTietSuatAn(int idUser, int idChiTietSuatAn, int Soluong)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "update ChiTietSuatAn set Soluong = @soluong where IDUser = @iduser and ID = @idctsuatan";
            command.Parameters.AddWithValue("@iduser", idUser);
            command.Parameters.AddWithValue("@idctsuatan", idChiTietSuatAn);
            command.Parameters.AddWithValue("@soluong", Soluong);

            command.ExecuteNonQuery();

            command.Parameters.Clear();
            conn.Close();
        }

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