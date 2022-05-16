using Quanlicaan.Models.Session;
using Quanlicaan.Models.ShowModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class UserLoginController : Controller
    {
        string connectionString = @"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True";
        SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");

        // GET: UserLogin
        public ActionResult Details(userModel usm)
        {
            userSession us = (userSession)Session["user"];
            if(us != null) { 
            usm.ID = us.ID;
            usm.HoTen = us.HoTen;
            usm.GioiTinh = us.GioiTinh;
            usm.DiaChi = us.DiaChi;
            usm.ChucVu = us.ChucVu;
            usm.username = us.username;
            usm.PhongBan = us.PhongBan;
            usm.IDrole = us.IDRole;
            usm.upassword = us.upassword;
            usm.RoleRegist = us.RoleRegist;
            usm.SDT = us.SDT;
            usm.trangthai = us.trangthai;

            return View(usm);
            }
            else
            {
                ViewBag.error = "Ban chua dang nhap !";
                return Redirect("~/Login/Login");
            }
        }

  
        

        // GET: UserLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserLogin/Create
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

        // GET: UserLogin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserLogin/Edit/5
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

        // GET: UserLogin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserLogin/Delete/5
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
