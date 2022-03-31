using Quanlicaan.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class PhongBanController : Controller

    {
        public ActionResult ShowAll()
        {

            var entities = new Model1();

            return View(entities.PhongBans.ToList());

        }


        private Model1 db = new Model1();

        public ActionResult EditPB(int id = 0)
        {

            PhongBan pb = db.PhongBans.Find(id);

            if (pb == null)

            {

                return HttpNotFound();

            }

            return View(pb);

        }


        [HttpPost]

        public ActionResult EditPB(PhongBan pb)

        {

            if (ModelState.IsValid)

            {

                db.Entry(pb).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("ShowAll");

            }

            return View(pb);

        }



        public ActionResult AddPB(PhongBan pb)

        {

            if (ModelState.IsValid)

            {

                db.PhongBans.Add(pb);

                db.SaveChanges();

                return RedirectToAction("ShowAll");

            }

            return View(pb);

        }

    }
}