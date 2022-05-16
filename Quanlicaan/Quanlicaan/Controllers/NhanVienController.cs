
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using Quanlicaan.Models.DAO;
using System.Linq;
using System.Data.Entity;
using System.Data;
using Quanlicaan.Models.Framework;

namespace Quanlicaan.Controllers
{
    public class NhanVienController : Controller
    {
   

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
            //sử dụng cho việc chọn các phòng ban
            var pb = new PhongbanModel();
            DataSet ds = pb.getAllPhongBan();
            ViewBag.phongBan = ds.Tables["PhongBan"];

            // sử dụng trong việc chọn phân quyền nhân viên
            var role = new RolerModel();
            ds = role.getAllRoler();
            ViewBag.Role = ds.Tables["Role"];


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
            //sử dụng cho việc chọn các phòng ban
            var pb = new PhongbanModel();
            DataSet ds = pb.getAllPhongBan();
            ViewBag.phongBan = ds.Tables["PhongBan"];

            // sử dụng trong việc chọn phân quyền nhân viên
            var role = new RolerModel();
            ds = role.getAllRoler();
            ViewBag.Role = ds.Tables["Role"];

            if (ModelState.IsValid)
            {
                var nhanvien = new UserModel();
                bool check = nhanvien.AddNv(nv);
                if (check)
                {
                    Response.Write("<script>alert('Thêm nhân viên thành công')</script>");
                    return RedirectToAction("Show", "NhanVien");
                }
                    
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