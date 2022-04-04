using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using System.Configuration;
using Quanlicaan.Models;
using System.Data;

namespace Quanlicaan.DataAccessLayer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public void Add_Record(NhanVienModel nv)
        {
            SqlCommand com = new SqlCommand("Sp_NhanVien_Add", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@hoTen",nv.hoTen);
            com.Parameters.AddWithValue("@IDPhongBan",nv.IDPhongBan);
            com.Parameters.AddWithValue("@username",nv.username);
            com.Parameters.AddWithValue("@password",nv.password);
            com.Parameters.AddWithValue("@IDRole",nv.IDRole);
            com.Parameters.AddWithValue("@quyen",nv.quyen);
            com.Parameters.AddWithValue("@trangThai",nv.trangThai);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Update_Record(NhanVienModel nv)
        {
            SqlCommand com = new SqlCommand("Sp_NhanVien_Update", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", nv.ID);
            com.Parameters.AddWithValue("@hoTen", nv.hoTen);
            com.Parameters.AddWithValue("@IDPhongBan", nv.IDPhongBan);
            com.Parameters.AddWithValue("@username", nv.username);
            com.Parameters.AddWithValue("@password", nv.password);
            com.Parameters.AddWithValue("@IDRole", nv.IDRole);
            com.Parameters.AddWithValue("@quyen", nv.quyen);
            com.Parameters.AddWithValue("@trangThai", nv.trangThai);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Show_Record_ById(int id)
        {
            SqlCommand com = new SqlCommand("Sp_NhanVien_Id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_All_Data()
        {
            SqlCommand com = new SqlCommand("Sp_NhanVien_All", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void Delete_Record(int id)
        {
            SqlCommand com = new SqlCommand("Sp_NhanVien_Id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}