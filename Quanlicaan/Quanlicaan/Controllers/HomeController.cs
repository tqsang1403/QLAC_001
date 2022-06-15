using Quanlicaan.Models.DAO;
using Quanlicaan.Models.Framework;
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
            ChiTietSuatAnModel suatAnModel = new ChiTietSuatAnModel();
            List<EdiDkiCaAnModelPage> list = suatAnModel.getAllSuatAnDangKi(us.IdPhongBan ,us.UserID);
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

    }
}