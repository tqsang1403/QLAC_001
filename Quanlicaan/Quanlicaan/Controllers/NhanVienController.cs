using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using Quanlicaan.Models;
using System.Linq;
using System.Data.Entity;
using System.Data;
using Quanlicaan.DataAccessLayer;

namespace Quanlicaan.Controllers
{
    public class NhanVienController : Controller
    {
        db dbLayer = new db();

        public ActionResult Show()

        {
            DataSet ds = dbLayer.Show_All_Data();
            ViewBag.nv = ds.Tables[0];
            return View();
        }
        public ActionResult Add_Record()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Add_Record(NhanVienModel fc)
        {
            NhanVienModel nv = new NhanVienModel();
            nv.hoTen = fc.hoTen;
            nv.IDPhongBan = fc.IDPhongBan;
            nv.username = fc.username;
            nv.password = fc.password;
            nv.IDRole = fc.IDRole;
            nv.quyen = fc.quyen;
            nv.trangThai = fc.trangThai;
            dbLayer.Add_Record(nv);
            TempData["msg2"] = "inserted!";
            return RedirectToAction("Show");


        }
        public ActionResult Update_Record(int ID)
        {
            DataSet ds = dbLayer.Show_Record_ById(ID);
            ViewBag.NhanVienRecord = ds.Tables[0];
            return View();

        }
        [HttpPost]
        public ActionResult Update_Record(int ID, NhanVienModel fc)
        {
            NhanVienModel nv = new NhanVienModel();
            nv.ID = ID;
            nv.hoTen = fc.hoTen;
            nv.IDPhongBan = fc.IDPhongBan;
            nv.username = fc.username;
            nv.password = fc.password;
            nv.IDRole = fc.IDRole;
            nv.quyen = fc.quyen;
            nv.trangThai = fc.trangThai;
            dbLayer.Update_Record(nv);
            TempData["msg"] = "đã update dữ liệu !";
            return RedirectToAction("Show");

        }
        public ActionResult Delete_Record(int ID)
        {
            dbLayer.Delete_Record(ID);
            TempData["msg"] = "deleted!";
            return RedirectToAction("Show");

        }
    }
}