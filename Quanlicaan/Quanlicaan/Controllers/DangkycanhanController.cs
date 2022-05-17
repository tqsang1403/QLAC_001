using Quanlicaan.Models;
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
        
        DangkycanhanModel dkcn = new DangkycanhanModel();
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


        [HttpPost]
       
        public ActionResult XuLyDangKyCaNhan(DangkycanhanModel dangkycanhanModel)
        {
            String thongbao = "";
            try
            {
                dkcn.RegistPersonalMeal(dangkycanhanModel);
                thongbao = "Regist Success !";

            }
            catch (Exception ex)
            {
                thongbao = "Regist Failed !";
            }
            return RedirectToAction("Home2", "Home", new { thongbao });
        }
    }
}