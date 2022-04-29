using Quanlicaan.Models.ModelADO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
{
    public class dbConnect
    {
        string connectionString = @"Data Source=ADMIN-PC;Initial Catalog=QuanLiCaAn;Integrated Security=True";
        

        public int Get_IDPhongBan_ById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Int32 IDPhongBan = 0;
                string sql = "SELECT IDPhongBan from NhanVien where ID = @ID";
                SqlCommand com = new SqlCommand(sql, conn);
                com.Parameters.Add("@ID", SqlDbType.Int);
                com.Parameters["@ID"].Value = id;

                try
                {
                    conn.Open();
                    IDPhongBan = (Int32)com.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return (int)IDPhongBan;
            }
        }

        public DataSet Get_Employee_By_IDPhongBan(int IDPhongBan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand("Sp_Get_Employee_By_IDPhongBan", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                com.Parameters.AddWithValue("@IDPhongBan", IDPhongBan);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }


        public void Add_New_GroupRegister(DangkyantaptheModel model)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand("Sp_Add_New_GroupRegister", conn);
                com.CommandType = System.Data.CommandType.StoredProcedure;
            }
        }

    }
}