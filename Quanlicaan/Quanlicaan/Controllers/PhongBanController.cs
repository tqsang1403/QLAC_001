using Quanlicaan.DataAccess;
using Quanlicaan.Models.DAO;
using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data;
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

            
            PhongbanModel pb = new PhongbanModel();
            DataSet ds = pb.getAllPhongBan();
            ViewBag.ListPhongBan = ds.Tables["PhongBan"];

            return View();

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



        public ActionResult AddPB()

        {

           

            return View();

        }

    }
}