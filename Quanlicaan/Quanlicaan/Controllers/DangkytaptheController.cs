using Quanlicaan.Models;
using Quanlicaan.Models.ModelADO;
using Quanlicaan.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class DangkytaptheController : Controller
    {
        dbConnect db = new dbConnect();
        public ActionResult TapThe()
        {

            userSession userLogin = (userSession)Session["user"];
            DangkyantaptheModel model = new DangkyantaptheModel();
            model.HoTenNDK= userLogin.HoTen;
            model.PhongBan = userLogin.PhongBan;
            model.ngayDK = DateTime.Now;
            model.khoiTaoDsNV(userLogin.IDPhongBan);
            //model ở đây cần khởi tạo 4 thuộc tính có sẵn giá trị 
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XuLyDangKyTapThe(DangkyantaptheModel model)
        {
            String thongbao = "";
            try
            {
                db.Add_New_GroupRegister(model);
                thongbao = "them moi thanh cong";
            }
            catch (Exception ex)
            {
                thongbao = "them moi that bai";
            }
            return RedirectToAction("TapThe", "Dangkytapthe", new { thongbao });
        }



    }
}