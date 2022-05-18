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

        public ActionResult AddPhongBan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhongBan( PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                PhongbanModel pb = new PhongbanModel();
                pb.addPhongBan(phongBan.TenPB);
                return RedirectToAction("ShowAll", "PhongBan");
            }
            else
            {
                return View();
            }
            
        }


        public ActionResult EditPB(int ID)
        {
            PhongbanModel pb = new PhongbanModel();
            PhongBan model = pb.getAllPhongBan(ID);
            return View(model);
        }


        [HttpPost]
        public ActionResult EditPB(PhongBan phongBanModel)
        {
            PhongbanModel pb = new PhongbanModel();
            pb.updatePhongBan(phongBanModel.TenPB, phongBanModel.ID);
            return RedirectToAction("ShowAll", "PhongBan");
        }


    }
}