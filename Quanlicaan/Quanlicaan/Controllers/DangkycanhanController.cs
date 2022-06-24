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
            var timeca1 = "09:00:00";
            var timeca23 = "15:00:00";

            var timedk = string.Format("{0:HH:mm:ss}", dangkycanhanModel.ngayDK);
            int checktimeca1 = String.Compare(timedk, timeca1, comparisonType: StringComparison.OrdinalIgnoreCase);
            int checktimeca23 = String.Compare(timedk, timeca23, comparisonType: StringComparison.OrdinalIgnoreCase);
            // so sánh tgian 1 và tgian2, nếu gt so sánh < 0 thì tg1 < tg2 và ngc lại
            try
            {
                if (checktimeca1 < 0 && dangkycanhanModel.SLCa1 >= 0)
                {
                    dkcn.RegistPersonalMeal(dangkycanhanModel);
                    thongbao = "Dang ky an thanh cong !";
                }
                else if(checktimeca1 > 0 && dangkycanhanModel.SLCa1 > 0)
                {
                    thongbao = " Dang ky an ca 1 that bai ! Ngoai gio dang ky an ca 1: thoi gian dang ky: '"+timedk+ "' > '" + timeca1 + "' ";
                    RedirectToAction("Home2", "Home", new { thongbao });
                }
                
                else if((checktimeca23 <0 && dangkycanhanModel.SLCa2 >= 0) || (checktimeca23 < 0 && dangkycanhanModel.SLCa3 >= 0))
                {
                    dkcn.RegistPersonalMeal(dangkycanhanModel);
                    thongbao = "Dang ky an thanh cong !";
                }
                else if ((checktimeca23 < 0 && dangkycanhanModel.SLCa2 >= 0 && dangkycanhanModel.SLCa3 >= 0))
                {
                    dkcn.RegistPersonalMeal(dangkycanhanModel);
                    thongbao = "Dang ky an thanh cong !";
                }
                else if((checktimeca23 > 0 && dangkycanhanModel.SLCa2 >= 0))
                {
                    thongbao = "Dang ky an ca 2 that bai! Ngoai gio dang ky an ca 2 ! (thoi gian dang ky: '" + timedk + "' > thoi gian quy dinh:'" + timeca23 + "') ";
                    RedirectToAction("Home2", "Home", new { thongbao });
                }
                else if(checktimeca23 > 0 && dangkycanhanModel.SLCa3 >= 0)
                {
                    thongbao = "Dang ky an ca 2 that bai! Ngoai gio dang ky an ca 3 ! (thoi gian dang ky: '" + timedk + "' > thoi gian quy dinh:'" + timeca23 + "') ";
                    RedirectToAction("Home2", "Home", new { thongbao });
                }
                    
            }
            catch (Exception ex)
            {
                thongbao = "Đăng ký thất bại !";
            }
            return RedirectToAction("Home2", "Home", new { thongbao });
        }
    }
}