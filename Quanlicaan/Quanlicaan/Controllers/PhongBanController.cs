using Quanlicaan.Models.ModelADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class PhongBanController : Controller
    {

        string connectionString = @"Data Source=ADMIN-PC;Initial Catalog=QuanLiCaAn;Integrated Security=True";
        // GET: PhongBan
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblPhongBan = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from PhongBan", conn);
                sqlDataAdapter.Fill(dtblPhongBan);
            }
            return View(dtblPhongBan);
        }

       
     

        // GET: PhongBan/Create
        public ActionResult Create()
        {
            return View(new PhongBanModel());
        }

        // POST: PhongBan/Create
        [HttpPost]
        public ActionResult Create(PhongBanModel phongbanModel)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                try
                {
                    conn.Open();
                    string query = "insert into PhongBan values(@TenPB)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@TenPB", phongbanModel.TenPB);


                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Content("<script language='javascript' type='text/javascript'>alert(' Thêm mới thất bại ! Không được để trống');</script>");
                }
                
                
                    return RedirectToAction("Index");
                
            }
            
        }

        // GET: PhongBan/Edit/5
        public ActionResult Edit(int id)
        {
            PhongBanModel phongBanModel = new PhongBanModel();
            DataTable dtblPhongBan = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select * from PhongBan where ID=@ID";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlDataAdapter.Fill(dtblPhongBan);
            }
            if (dtblPhongBan.Rows.Count == 1)
            {
                phongBanModel.TenPB = Convert.ToString(dtblPhongBan.Rows[0][1].ToString());
               
               
                return View(phongBanModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: PhongBan/Edit/5
        [HttpPost]
        public ActionResult Edit(PhongBanModel phongbanModel)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update PhongBan set TenPB = @TenPB where ID = @ID ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", phongbanModel.ID);
                cmd.Parameters.AddWithValue("@TenPB", phongbanModel.TenPB);
                
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            return RedirectToAction("Index");
        }

     
     
        public ActionResult Delete(int id)
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Delete from PhongBan where ID = @ID ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
    }
}
