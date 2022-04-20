
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

        // select nhân viên
        public ActionResult Show(string tennv)
        {

            ViewBag.Keyword = tennv;
            var nhanvien = new UserModel();
            List<NhanVien> list = nhanvien.Listnv(tennv);
            return View(list);

        }


        //SỬA NV
        [HttpGet]
        public ActionResult EditNV(int id)
        {
            var nhanvien = new UserModel();
            NhanVien employee = nhanvien.ListnvUpdate(id);
            return View(employee);

        }


        [HttpPost]
        public ActionResult EditNV(NhanVien nv)

        {
            var nhanvien = new UserModel();
            nhanvien.UpdateNv(nv);
            return RedirectToAction("Show", "NhanVien");


        }

        //XOÁ NV

        public ActionResult Delete(int id)

        {
            var nhanvien = new UserModel();
            nhanvien.DeleteNv(id);
            return RedirectToAction("Show", "NhanVien");

        }

        ///THÊM NHÂN VIÊN MƯỚI
        [HttpGet]
        public ActionResult AddNV(NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                var nhanvien = new UserModel();
                bool check = nhanvien.AddNv(nv);
                if (check)
                    return RedirectToAction("Show", "NhanVien");
                else
                    return View();
            }
            else
            {
                return View();
            }
        }


    }

}