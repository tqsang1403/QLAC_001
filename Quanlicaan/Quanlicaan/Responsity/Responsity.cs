using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Quanlicaan.Responsity
{
    public class Responsity
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details    
        public bool AddPB(PhongBan obj)
        {

            connection();
            SqlCommand com = new SqlCommand("addnewphongban", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TenPB", obj.TenPB);
            

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view employee details with generic list     
        public List<PhongBan> GetAllPB()
        {
            connection();
            List<PhongBan> EmpList = new List<PhongBan>();


            SqlCommand com = new SqlCommand("GetAllPB", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new PhongBan
                    {

                        ID = Convert.ToInt32(dr["Id"]),
                        TenPB = Convert.ToString(dr["Name"]),
                        

                    }
                    );
            }

            return EmpList;
        }
        //To Update Employee details    
        public bool UpdatePB(PhongBan obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdatePhongBan", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TenPB", obj.TenPB);
           
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
   
       
    }
}
        
