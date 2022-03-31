using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using Quanlicaan.Models;
using System.Linq;
using System.Data.Entity;

namespace Quanlicaan.Controllers
{
    public class NhanVienController : Controller
    {
        private Model1 db = new Model1(); 

        public ActionResult Show()

        {

            var entities = new Model1();

            return View(entities.NhanViens.ToList());

        }
       

        //SỬA NV

        public ActionResult EditNV(int id = 0)
        {

            NhanVien nv = db.NhanViens.Find(id);

            if (nv == null)

            {

                return HttpNotFound();

            }

            return View(nv);

        }


        [HttpPost]

        public ActionResult EditNV(NhanVien nv)

        {

            if (ModelState.IsValid)

            {

                db.Entry(nv).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Show");

            }

            return View(nv);

        }

        //XOÁ NV

        public ActionResult Delete(int id = 0)

        {

            NhanVien nv = db.NhanViens.Find(id);

            if (nv == null)

            {

                return HttpNotFound();

            }

            return View(nv);

        }


        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)

        {

            NhanVien nv = db.NhanViens.Find(id);

            db.NhanViens.Remove(nv);

            db.SaveChanges();

            return RedirectToAction("Show");

        }





        ///THÊM NHÂN VIÊN MƯỚI
        public ActionResult AddNV()
        {
            return View("AddNV");
        }

        [HttpPost]

        public ActionResult AddNV(NhanVien nv)

        {

            if (ModelState.IsValid)

            {

                db.NhanViens.Add(nv);

                db.SaveChanges();

                return RedirectToAction("Show");

            }

            return View(nv);

        }
    }
}