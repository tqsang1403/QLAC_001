using Quanlicaan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class CaAnController : Controller
    {
        // GET: CaAn
        public ActionResult Index()
        {
            DangKyCaNhanModel model = new DangKyCaNhanModel();
            UserLoginModel userLogin =(UserLoginModel) Session["UserSession"];
            model.hoTen = userLogin.hoTen;
            model.phongBan = userLogin.PhongBan;
            model.ngayDK = DateTime.Now.AddDays(1);
            return View(model);
        }
        [HttpPost]
        public ActionResult XuLyDangKyCaNhan(DangKyCaNhanModel d)
        {

            return View();
        }
        public ActionResult TapThe()
        {

            return View();
        }

        // GET: CaAn/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CaAn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaAn/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CaAn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CaAn/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CaAn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CaAn/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
