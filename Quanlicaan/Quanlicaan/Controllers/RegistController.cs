using Quanlicaan.Models;
using System;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class RegistController : Controller
    {
        private Model1 db = new Model1();
        // GET: Regist
        [HttpGet]
        public ActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Regist(NhanVienModel nv)
        {
            
            return Redirect("/NhanVien/Show");
        }

    }
}


