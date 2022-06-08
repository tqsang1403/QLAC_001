using Quanlicaan.Models.DAO;
using Quanlicaan.Models.Framework;
using Quanlicaan.Models.ModelsPage;
using Quanlicaan.Models.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class DangkycaanController : Controller
    {

        public ActionResult DkiCanhan( )
        {
            SuatAnModel suatanmodel = new SuatAnModel();
            DkiCaNhanModel model = new DkiCaNhanModel();
            UserSession us = (UserSession)Session["UserSession"];


            CaAnModel caanmodel = new CaAnModel();
            List<CaAn> listcaan = caanmodel.GetCaAns();

            model.TimeCa1 = listcaan[0].Thoigian;
            model.TimeCa2 = listcaan[1].Thoigian;
            model.TimeCa3 = listcaan[2].Thoigian;

            model.hoTen = us.hoTen;
            model.phongBan = us.TenPhongBan;
            model.ngayDK = DateTime.Now;
            model.SLCa1 = suatanmodel.getSLSuatAn(us.UserID , 1);
            model.SLCa2 = suatanmodel.getSLSuatAn(us.UserID , 2);
            model.SLCa3 = suatanmodel.getSLSuatAn(us.UserID , 3);
            return View(model);

        }


        // ĐĂNG KÍ CA ĂN CÁ NHÂN
        [HttpPost]
        public ActionResult DkiCanhan(DkiCaNhanModel model)
        {
            if (ModelState.IsValid)
            {
                string thongbao;
                UserSession us1 = (UserSession)Session["UserSession"];
                SuatAnModel samodel = new SuatAnModel();
                string now = DateTime.Now.ToString();
                // đăng kí suất ăn
                samodel.InsertSuatAn(us1.UserID, now);

                if (model.check1 == true && model.SLCa1 > 0)
                {
                    samodel.InsertCTSuatAn(us1.UserID, now, 1, model.SLCa1);

                }

                if (model.check2 == true && model.SLCa2 > 0)
                {
                    samodel.InsertCTSuatAn(us1.UserID, now, 2, model.SLCa2);

                }

                if (model.check3 == true && model.SLCa3 > 0)
                {
                    samodel.InsertCTSuatAn(us1.UserID, now, 3, model.SLCa3);

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

            SuatAnModel samodel = new SuatAnModel();
            CaAnModel caAnModel = new CaAnModel();
            UserSession us = (UserSession)Session["UserSession"];
            DataSet ds = samodel.getAllNhanVienCungPhongBan(us.IdPhongBan);
            List<DkiCaAnTapTheModel> list = new List<DkiCaAnTapTheModel>();
            var time = DateTime.Now;
            foreach (DataRow dr in ds.Tables["DanhSachNvCungPhong"].Rows)
            {
                DkiCaAnTapTheModel model = new DkiCaAnTapTheModel();
                model.IDUser = Convert.ToInt32(dr["ID"]);
                model.hoTen = dr["HoTen"].ToString();
                model.phongBan = dr["TenPB"].ToString();
                model.ngayDK = time;
                model.ListCaAn = caAnModel.GetCaAns(us.UserID);
                list.Add(model);
            }

            return View(list);
        }



        // THỰC HIỆN ĐĂNG KÍ TẬP THỂ
        [HttpPost]
        public ActionResult DkiTapThe(List<DkiCaAnTapTheModel> list)
        {
            if (ModelState.IsValid)
            {
                string thongbao;
                UserSession us = (UserSession)Session["UserSession"];
                SuatAnModel samodel = new SuatAnModel();
                string time = DateTime.Now.ToString();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].TrangThai == true)
                    {
                        samodel.InsertSuatAn(list[i].IDUser, time);

                        //foreach (var item in list[i].ListCaAn)
                        //{
                        //    if (item.IsChecked && item.ID == 1 && item.SoluongSuatan > 0)
                        //    {
                        //        samodel.InsertCTSuatAn(list[i].IDUser, time, item.ID, item.SoluongSuatan);

                        //    }

                        //    if (item.IsChecked && item.ID == 2 && item.SoluongSuatan > 0)
                        //    {
                        //        samodel.InsertCTSuatAn(list[i].IDUser, time, item.ID, item.SoluongSuatan);

                        //    }

                        //    if (item.IsChecked && item.ID == 3 && item.SoluongSuatan > 0)
                        //    {
                        //        samodel.InsertCTSuatAn(list[i].IDUser, time, item.ID, item.SoluongSuatan);

                        //    }
                        //}


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
        public ActionResult EditDkiCaanCanhan()
        {
            UserSession us = (UserSession)Session["UserSession"];
            SuatAnModel suatAnModel = new SuatAnModel();
            List<EdiDkiCaAn> list = suatAnModel.getAllSuatAnDangKi(us.IdPhongBan, us.UserID);
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
        public ActionResult EditDkiCaanCanhan(List<EdiDkiCaAn> model)
        {
            SuatAnModel suatAnModel = new SuatAnModel();
            for (int i = 0; i < model.Count; i++)
            {
                suatAnModel.UpDateChiTietSuatAn(model[i].IDUser, model[i].IDChiTietSuatAn, model[i].Soluong);
            }
            ViewBag.updateSucess = "Bạn đã cập nhật thành công";
            return RedirectToAction("Home", "Home");
        }

        // thực hiện xóa thông tin nhân viên
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            SuatAnModel suatAnModel = new SuatAnModel();
            suatAnModel.DeleteChiTietSuatAn(ID);
            return RedirectToAction("Home", "Home");
        }

    }

}