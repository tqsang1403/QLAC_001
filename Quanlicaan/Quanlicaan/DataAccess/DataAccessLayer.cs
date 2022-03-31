using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.DataAccess
{
    public class DataAccessLayer
    {
        public string InsertData(PhongBan objpb)

        {



            SqlConnection con = null;

            string result = "";

            try

            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_PhongBan", con);

                cmd.CommandType = CommandType.StoredProcedure;

                

                cmd.Parameters.AddWithValue("@Name", objpb.TenPB);


                cmd.Parameters.AddWithValue("@Query", 1);

                con.Open();

                result = cmd.ExecuteScalar().ToString();

                return result;

            }

            catch

            {

                return result = "";

            }

            finally

            {

                con.Close();

            }

        }

        public string UpdateData(PhongBan objpb)

        {

            SqlConnection con = null;

            string result = "";

            try

            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_PhongBan", con);

                cmd.CommandType = CommandType.StoredProcedure;

                

                cmd.Parameters.AddWithValue("@TenPB", objpb.TenPB);

               

                cmd.Parameters.AddWithValue("@Query", 2);

                con.Open();

                result = cmd.ExecuteScalar().ToString();

                return result;

            }

            catch

            {

                return result = "";

            }

            finally

            {

                con.Close();

            }

        }


        public string DeleteData(PhongBan objpb)

        {

            SqlConnection con = null;

            string result = "";

            try

            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_PhongBan", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TenPB", null);

                cmd.Parameters.AddWithValue("@Query", 3);

                con.Open();

                result = cmd.ExecuteScalar().ToString();

                return result;

            }

            catch

            {

                return result = "";

            }

            finally

            {

                con.Close();

            }

        }


        public List<PhongBan> Selectalldata()

        {

            SqlConnection con = null;



            DataSet ds = null;

            List<PhongBan> list = null;

            try

            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_PhongBan", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", null);

                cmd.Parameters.AddWithValue("@TenPB",null);

                cmd.Parameters.AddWithValue("@Query", 4);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                ds = new DataSet();

                da.Fill(ds);

                list = new List<PhongBan>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)

                {

                    PhongBan cobj = new PhongBan();

                    

                    cobj.ID = (int)ds.Tables[0].Rows[i]["ID"];
                    cobj.TenPB = ds.Tables[0].Rows[i]["Tên Phòng Ban"].ToString();



                    list.Add(cobj);

                }

                return list;

            }

            catch

            {

                return list;

            }

            finally

            {

                con.Close();

            }

        }


        //end 
    }
}