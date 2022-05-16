using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home(string thongbao)
        {
            ViewData["message"] = thongbao;
            return View();
        }

    }
}