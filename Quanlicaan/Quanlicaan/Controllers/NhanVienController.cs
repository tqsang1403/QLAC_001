
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using Quanlicaan.Models.DAO;
using System.Linq;
using System.Data.Entity;
using System.Data;
using Quanlicaan.Models.Framework;
using System.Dynamic;
using System.Web.UI.WebControls;
using Quanlicaan.Models.ModelsPage;
using Quanlicaan.Models.Session;
using PagedList;

namespace Quanlicaan.Controllers
{
    public class NhanVienController : Controller
    {
   

        // select nhân viên
        public ActionResult Show(string tennv, string idPhongBan, int? page)
        {

            if (page == null) page = 1;
            int pageSize = 5;
            //  Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);


            ViewBag.Keyword = tennv;
           // ViewBag.TenPhongBan = tenPhongBan;
            var nhanvien = new UserModel();
            List<NhanVien> list = nhanvien.Listnv(tennv, idPhongBan);
            list.ToList();

            var phongBan = new PhongbanModel();
            DataSet ds = new DataSet();
            ds = phongBan.getAllPhongBan();
            ViewBag.Phongbans = ds.Tables["PhongBan"];


            IPagedList<NhanVien> stu3 = null;
            stu3 = list.ToPagedList(pageNumber, pageSize);
            return View(stu3);

        }

        public ActionResult FindPBNV(string tenPhongBan)
        {

            ViewBag.TenPhongBan = tenPhongBan;
            var nhanvien = new UserModel();
            List<NhanVien> list = nhanvien.FinPbNV(tenPhongBan);
            return RedirectToAction("Show");

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
       

        //THÊM NHÂN VIÊN MỚI
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


        // LẤY THÔNG TIN CÁ NHÂN NGƯỜI ĐĂNG NHẬP
        [HttpGet]
        public ActionResult PerSonal()
        {
            UserSession us = (UserSession)Session["UserSession"];
            UserModel usermodel = new UserModel();
            PersonalModelPage personal = new PersonalModelPage();
            personal = usermodel.getPerSonal(us.UserID);
            return View(personal);
        }


        //UPDATE THÔNG TIN CÁ NHÂN ĐĂNG NHẬP
        [HttpPost]
        public ActionResult PerSonal(PersonalModelPage model)
        {
            UserSession us = (UserSession)Session["UserSession"];
            UserModel usermodel = new UserModel();
            usermodel.UpdatePersonal(model, us.UserID);
            ViewBag.success = "Bạn cập nhật thông tin thành công";
            return RedirectToAction("PerSonal");
        }


        // LÂY THÔNG TIN TÀI KHOẢN MẬT KHẨU
        [HttpGet]
        public ActionResult EditPass()
        {

            UserSession us = (UserSession)Session["UserSession"];
            UserModel usermodel = new UserModel();
            PersonalModelPage personal = new PersonalModelPage();
            personal = usermodel.getPerSonal(us.UserID);
            return View(personal);
        }

        // UPDATE THÔNG TIN MẬT KHẨU
        [HttpPost]
        public ActionResult EditPass(PersonalModelPage model)
        {
            UserSession us = (UserSession)Session["UserSession"];
            UserModel usermodel = new UserModel();
            usermodel.UpdatePersonal(model.username, model.upassword, us.UserID);
            ViewBag.success = "Bạn cập nhật thông tin thành công";
            return RedirectToAction("PerSonal") ;
        }

    }

}