using Quanlicaan.Models.ModelADO;
using Quanlicaan.Models.Session;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class DangkycanhanController : Controller
    {
        string connectionString = @"Data Source=ADMIN-PC;Initial Catalog=QuanLiCaAn;Integrated Security=True";
        // GET: Dangkycanhan
        public ActionResult Dangkycanhan(string Thongbao)
        {

            ViewData["message"] = Thongbao;
            DangkycanhanModel dangkycanhanModel = new DangkycanhanModel();
            userSession us = (userSession)Session["user"];

            dangkycanhanModel.HoTen = us.HoTen;
            dangkycanhanModel.PhongBan = us.PhongBan;
            dangkycanhanModel.ngayDK = DateTime.Now;


            return View(dangkycanhanModel);
        }

        public ActionResult XuLyDangKyCaNhan(DangkycanhanModel model)
        {
            String thongbao = "";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
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
                thongbao = "them moi thanh cong";

            }
            catch (Exception ex)
            {
                thongbao = "them moi that bai";
            }
            return RedirectToAction("Dangkycanhan", "Dangkycanhan", new { thongbao });
        }
    }
}