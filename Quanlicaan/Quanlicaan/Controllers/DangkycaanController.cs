using Quanlicaan.Models.DAO;
using Quanlicaan.Models.Framework;
using Quanlicaan.Models.ModelsPage;
using Quanlicaan.Models.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class DangkycaanController : Controller
    {

        public ActionResult DkiCanhan()
        {
            ChiTietSuatAnModel suatanmodel = new ChiTietSuatAnModel();
            DkiCaNhanModelPage model = new DkiCaNhanModelPage();
            UserSession us = (UserSession)Session["UserSession"];


            CaAnModel caanmodel = new CaAnModel();
            List<CaAn> listcaan = caanmodel.GetCaAns();

            model.TimeCa1 = listcaan[0].Thoigian;
            model.TimeCa2 = listcaan[1].Thoigian;
            model.TimeCa3 = listcaan[2].Thoigian;

            model.hoTen = us.hoTen;
            model.phongBan = us.TenPhongBan;
            model.ngayDK = DateTime.Now;
            model.SLCa1 = suatanmodel.getSLSuatAn(us.UserID, 1);
            model.SLCa2 = suatanmodel.getSLSuatAn(us.UserID, 2);
            model.SLCa3 = suatanmodel.getSLSuatAn(us.UserID, 3);
            return View(model);

        }


        // ĐĂNG KÍ CA ĂN CÁ NHÂN
        [HttpPost]
        public ActionResult DkiCanhan(DkiCaNhanModelPage model)
        {
            if (ModelState.IsValid)
            {
                UserSession us1 = (UserSession)Session["UserSession"];
                ChiTietSuatAnModel samodel = new ChiTietSuatAnModel();
                string now = DateTime.Now.ToString();

                // đăng kí suất ăn cho cá nhân
                samodel.InsertSuatAn(us1.UserID, now, false);

                if (model.check1 == true && model.SLCa1 > 0)
                {
                    samodel.InsertCTSuatAn(us1.UserID, now, 1, model.SLCa1, us1.hoTen);

                }

                if (model.check2 == true && model.SLCa2 > 0)
                {
                    samodel.InsertCTSuatAn(us1.UserID, now, 2, model.SLCa2, us1.hoTen);

                }

                if (model.check3 == true && model.SLCa3 > 0)
                {
                    samodel.InsertCTSuatAn(us1.UserID, now, 3, model.SLCa3, us1.hoTen);

                }

                return RedirectToAction("Home", "Home");



            }
            else
            {
                ModelState.AddModelError("", "Đăng kí ca ăn thất bại!");
                return View();
            }
        }



        // HIỆN GIAO DIỆN ĐĂNG KÍ TẬP THỂ
        public ActionResult TapThe()
        {


            ChiTietSuatAnModel suatanmodel = new ChiTietSuatAnModel();
            CaAnModel caAnModel = new CaAnModel();
            UserSession us = (UserSession)Session["UserSession"];
            DataSet ds = suatanmodel.getAllNhanVienCungPhongBan(us.IdPhongBan);
            List<DkiCaAnTapTheModelPage> list = new List<DkiCaAnTapTheModelPage>();
            var time = DateTime.Now;




            foreach (DataRow dr in ds.Tables["DanhSachNvCungPhong"].Rows)
            {
                DkiCaAnTapTheModelPage model = new DkiCaAnTapTheModelPage();
                model.IDUser = Convert.ToInt32(dr["ID"]);
                model.hoTen = dr["HoTen"].ToString();
                model.phongBan = dr["TenPB"].ToString();
                model.ngayDK = time;


                CaAnModel caanmodel = new CaAnModel();
                List<CaAn> listcaan = caanmodel.GetCaAns();

                model.TimeCa1 = listcaan[0].Thoigian;
                model.TimeCa2 = listcaan[1].Thoigian;
                model.TimeCa3 = listcaan[2].Thoigian;


                model.SLCa1 = suatanmodel.getSLSuatAn(Convert.ToInt32(dr["ID"]), 1);
                model.SLCa2 = suatanmodel.getSLSuatAn(Convert.ToInt32(dr["ID"]), 2);
                model.SLCa3 = suatanmodel.getSLSuatAn(Convert.ToInt32(dr["ID"]), 3);
                // model.ListCaAn = caAnModel.GetCaAns(us.UserID);
                list.Add(model);
            }

            return View(list);
        }



        // THỰC HIỆN ĐĂNG KÍ TẬP THỂ
        [HttpPost]
        public ActionResult DkiTapThe(List<DkiCaAnTapTheModelPage> list)
        {
            if (ModelState.IsValid)
            {
                string thongbao;
                UserSession us = (UserSession)Session["UserSession"];
                ChiTietSuatAnModel samodel = new ChiTietSuatAnModel();
                string now = DateTime.Now.ToString();
               samodel.InsertSuatAn(us.UserID, now, true);



                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].TrangThai == true)
                    {


                        if (list[i].check1 == true && list[i].SLCa1 > 0)
                        {
                            samodel.InsertCTSuatAn(list[i].IDUser, us.UserID, now, 1, list[i].SLCa1, us.hoTen);

                        }

                        if (list[i].check2 == true && list[i].SLCa2 > 0)
                        {
                            samodel.InsertCTSuatAn(list[i].IDUser, us.UserID, now, 2, list[i].SLCa2, us.hoTen);

                        }

                        if (list[i].check3 == true && list[i].SLCa3 > 0)
                        {
                            samodel.InsertCTSuatAn(list[i].IDUser, us.UserID, now, 3, list[i].SLCa3, us.hoTen);

                        }


                    }
                    else
                    {
                        continue;
                    }

                }

                thongbao = "them moi thanh cong ";
                return RedirectToAction("Home", "Home", new { thongbao });
                

               

               
                

            }
            else
            {
                ModelState.AddModelError("", "Đăng kí ca ăn thất bại!");
                return View();
            }
        }



        // Hiển thị giao chỉnh sửa đăng kí ca ăn cá nhân
        [HttpGet]
        public ActionResult EditDkiCaanCanhan(int ID)
        {
            UserSession us = (UserSession)Session["UserSession"];
            ChiTietSuatAnModel suatAnModel = new ChiTietSuatAnModel();
            List<EdiDkiCaAnModelPage> list = suatAnModel.getAllSuatAnDangKi(us.IdPhongBan, us.UserID , ID);
            if (list.Count == 0)
            {
                ViewBag.message = "Bạn chưa đăng kí ca ăn hôm nay";
                return View(list);
            }
            else
            {
                return View(list);
            }
        }



        // Thực hiện chỉnh sửa thông tin đăng kí cá  nhân
        [HttpPost]
        public ActionResult EditDkiCaanCanhan(List<EdiDkiCaAnModelPage> model)
        {
            string now = DateTime.Now.ToString();
            ChiTietSuatAnModel suatAnModel = new ChiTietSuatAnModel();
            UserSession us = (UserSession)Session["UserSession"];
            for (int i = 0; i < model.Count; i++)
            {
                suatAnModel.UpDateChiTietSuatAn(model[i].IDUser, model[i].IDChiTietSuatAn, model[i].Soluong , now , us.hoTen );
            }
            ViewBag.updateSucess = "Bạn đã cập nhật thành công";
            return RedirectToAction("Home", "Home");
        }

        // thực hiện xóa thông tin nhân viên
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            ChiTietSuatAnModel suatAnModel = new ChiTietSuatAnModel();
            suatAnModel.DeleteChiTietSuatAn(ID);
            return RedirectToAction("Home", "Home");
        }

    }

}