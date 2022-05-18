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

        public ActionResult DkiCanhan(string thongBao)
        {
            ViewData["message"] = thongBao;
            CaAnModel caAnModel = new CaAnModel();
            DkiCaNhanModel model = new DkiCaNhanModel();
            UserSession us = (UserSession)Session["UserSession"];
            model.hoTen = us.hoTen;
            model.phongBan = us.TenPhongBan;
            model.ngayDK = DateTime.Now;
            model.ListCaAn = caAnModel.GetCaAns();
            return View(model);

        }


        [HttpPost]
        public ActionResult DkiCanhan(DkiCaNhanModel model)
        {
            if (ModelState.IsValid)
            {
                string thongbao;
                UserSession us1 = (UserSession)Session["UserSession"];
                SuatAnModel samodel = new SuatAnModel();
                string now = DateTime.Now.ToString();
                var check =  samodel.InsertSuatAn(us1.UserID,now);

                if (check)
                {
                    foreach (var item in model.ListCaAn)
                    {
                        if (item.IsChecked && item.ID == 1 && item.SoluongSuatan > 0)
                        {
                            samodel.InsertCTSuatAn(us1.UserID, now, item.ID, item.SoluongSuatan);
                            
                        }

                        if (item.IsChecked && item.ID == 2 && item.SoluongSuatan > 0)
                        {
                            samodel.InsertCTSuatAn(us1.UserID, now, item.ID, item.SoluongSuatan);
                            
                        }

                        if (item.IsChecked && item.ID == 3 && item.SoluongSuatan > 0)
                        {
                            samodel.InsertCTSuatAn(us1.UserID, now, item.ID, item.SoluongSuatan);
                            
                        }
                    }
                    thongbao = "them moi thanh cong ";
                    return RedirectToAction("Home", "Home" , new { thongbao });
                }
                else
                {
                    thongbao = "them moi  không thành công thanh cong ";
                    return View(new { thongbao});
                }

               
            }
            else
            {
                ModelState.AddModelError("", "Đăng kí ca ăn thất bại!");
                return View();
            }
        }


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
                model.ngayDK =time;
                model.ListCaAn = caAnModel.GetCaAns();
                list.Add(model);
            }

            return View(list);
        }


        [HttpPost]
        public ActionResult DkiTapThe(List<DkiCaAnTapTheModel> list)
        {
            if (ModelState.IsValid)
            {
                string thongbao;
                UserSession us = (UserSession)Session["UserSession"];
                SuatAnModel samodel = new SuatAnModel();
                string time =  DateTime.Now.ToString();
                for (int i = 0; i < list.Count; i++)
                {
                    if(list[i].TrangThai == true)
                    {
                        var check = samodel.InsertSuatAn(list[i].IDUser, time);
                        if (check)
                        {
                            foreach (var item in list[i].ListCaAn)
                            {
                                if (item.IsChecked && item.ID == 1 && item.SoluongSuatan > 0 )
                                {
                                    samodel.InsertCTSuatAn(list[i].IDUser, time, item.ID, item.SoluongSuatan);

                                }

                                if (item.IsChecked && item.ID == 2 && item.SoluongSuatan > 0)
                                {
                                    samodel.InsertCTSuatAn(list[i].IDUser, time, item.ID, item.SoluongSuatan);

                                }

                                if (item.IsChecked && item.ID == 3 && item.SoluongSuatan > 0)
                                {
                                    samodel.InsertCTSuatAn(list[i].IDUser, time, item.ID, item.SoluongSuatan);

                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Đăng kí ca ăn thất bại!");
                            return View();
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

       


        public ActionResult EditDkiCaanCanhan()
        {
            UserSession us = (UserSession)Session["UserSession"];
            SuatAnModel suatAnModel = new SuatAnModel();
            List<EdiDkiCaAn> list = suatAnModel.getAllSuatAnDangKi(us.IdPhongBan);
            if(list.Count == 0)
            {
                ModelState.AddModelError("", "Bạn chưa đăng kí ca ăn hôm nay");

                ViewBag.message = "Bạn chưa đăng kí ca ăn hôm nay";
                return View(list);
            }
            else
            {
                return View(list);
            }
        }


    }

 }