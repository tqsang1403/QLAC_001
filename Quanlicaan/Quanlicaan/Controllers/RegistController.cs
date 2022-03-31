using System;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class RegistController : Controller
    {
        private Model1 db = new Model1();
        // GET: Regist
        [HttpGet]
        public ActionResult Regist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Regist(NhanVien nv)
        {
            if (ModelState.IsValid)

            {

                db.NhanViens.Add(nv);

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(nv);
        }

    }
}


