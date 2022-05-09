using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class DangkycanhanModel
    {
        public string HoTen { get; set; }

        public int IDPhongBan { get; set; }

        [DisplayName("ngày đăng kí")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        public DateTime ngayDK { get; set; }

        public int SLCa1 { get; set; }

        public int SLCa2 { get; set; }

        public int SLCa3 { get; set; }

        public string PhongBan { get; set; }



        SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");

        public void RegistPersonalMeal(DangkycanhanModel model)
        {

            SqlCommand com = new SqlCommand("Sp_Dangkyancanhan", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@HoTen", model.HoTen);
            com.Parameters.AddWithValue("@PhongBan", model.PhongBan);
            com.Parameters.AddWithValue("@ngayDK", model.ngayDK);
            com.Parameters.AddWithValue("@SLCa1", model.SLCa1);
            com.Parameters.AddWithValue("@SLCa2", model.SLCa2);
            com.Parameters.AddWithValue("@SLCa3", model.SLCa3);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }

    }
}