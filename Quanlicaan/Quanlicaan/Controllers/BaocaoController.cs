using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class BaocaoController : Controller
    {
        // GET: Baocao
        public ActionResult Canhan()
        {
            return View("Baocaocanhan");
        }
        public ActionResult Theongay()
        {
            return View("Baocaotheongay");
        }
        public ActionResult Theothang()
        {
            return View("Baocaotheothang");
        }
    }
}