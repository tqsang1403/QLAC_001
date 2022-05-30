using Quanlicaan.Models.DAO;
using Quanlicaan.Models.ModelsPage;
using Quanlicaan.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            UserSession us = (UserSession)Session["UserSession"];
            SuatAnModel suatAnModel = new SuatAnModel();
            List<EdiDkiCaAn> list = suatAnModel.getAllSuatAnDangKi(us.IdPhongBan ,us.UserID);
            if (list.Count == 0)
            {
                ViewBag.message = "Bạn chưa đăng kí ca ăn ngày hôm nay ";
                return View(list);
            }
            else
            {
                return View(list);
            }
        }

        public ActionResult ReportPerson() 
        {
                return View();
        } 
    }
}