using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class DangkycaanController : Controller
    {
        // GET: Dangkycaan
        public ActionResult Canhan()
        {
            return View("dangkyancanhan");
        }



        public ActionResult Tapthe()
        {
            return View("dangkyantheonhom");
        }

    }
}