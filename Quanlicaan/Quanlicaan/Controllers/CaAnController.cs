using Quanlicaan.DataAccessLayer;
using Quanlicaan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Quanlicaan.Controllers
{
    public class CaAnController : Controller
    {
        db dbLayer = new db();
       
        // GET: CaAn
        public ActionResult Index(string thongBao)
        {
            ViewData["message"] = thongBao;
            DangKyCaNhanModel model = new DangKyCaNhanModel();
            UserLoginModel userLogin = (UserLoginModel)Session["UserSession"];
            model.hoTen = userLogin.hoTen;
            model.phongBan = userLogin.PhongBan;
            model.ngayDK = DateTime.Now;
            return View(model);
        }
        public ActionResult TapThe()
        {

            UserLoginModel userLogin = (UserLoginModel)Session["UserSession"];
            DangKyTapTheModel model = new DangKyTapTheModel();
            model.hoTenNDK = userLogin.hoTen;
            model.phongBan = userLogin.PhongBan;
            model.ngayDK = DateTime.Now;
            model.khoiTaoDsNV(userLogin.IDPhongBan);
            //model ở đây cần khởi tạo 4 thuộc tính có sẵn giá trị 
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XuLyDangKyTapThe(DangKyTapTheModel model)
        {
            String thongbao = "";
            try
            {
                dbLayer.Add_New_GroupRegister(model);
                thongbao = "them moi thanh cong";
            }
            catch (Exception ex)
            {
                thongbao = "them moi that bai";
            }
            return RedirectToAction("Index", "CaAn", new { thongbao });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XuLyDangKyCaNhan(DangKyCaNhanModel model)
        {
            String thongbao = "";
            try
            {
                dbLayer.Add_New_PersonalRegister(model);
                thongbao = "them moi thanh cong";

            }
            catch (Exception ex)
            {
                thongbao = "them moi that bai";
            }
            return RedirectToAction("Index", "CaAn", new { thongbao });
        }



      
    }
}
