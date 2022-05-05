using Quanlicaan.Models.DAO;
using Quanlicaan.Models.Framework;
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

        public ActionResult DkiCanhan()
        {
            List<CaAn> obj = new List<CaAn>()
           {
               new CaAn {ID=1,Thoigian = Convert.ToDateTime("2022-03-02 09:00:00.000") , IsChecked=false , SoluongSuatan=0 },
               new CaAn {ID=2, Thoigian = Convert.ToDateTime("2022-03-02 15:00:00.000") , IsChecked=false ,SoluongSuatan=0},
               new CaAn {ID=3, Thoigian = Convert.ToDateTime("2022-05-04 20:00:00.000") , IsChecked=false ,SoluongSuatan=0}
           };

            DkiCaNhanModel model = new DkiCaNhanModel();
            UserSession us = (UserSession)Session["UserSession"];
            model.hoTen = us.hoTen;
            model.phongBan = us.TenPhongBan;
            model.ngayDK = DateTime.Now;
            model.ListCaAn = obj;
            return View(model);

        }
        [HttpPost]
        public ActionResult DkiCanhan(DkiCaNhanModel model)
        {
            if (ModelState.IsValid)
            {
                UserSession us1 = (UserSession)Session["UserSession"];
                SuatAnModel samodel = new SuatAnModel();
                var now = DateTime.Now;
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
                    Response.Write("<script>alert('Đăng kí ca ăn cá nhân thành công')</script>");
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng kí ca ăn thất bại!");
                    return View();
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
            List<CaAn> obj = new List<CaAn>()
           {
               new CaAn {ID=1,Thoigian = Convert.ToDateTime("2022-03-02 09:00:00.000") , IsChecked=false , SoluongSuatan=0 },
               new CaAn {ID=2, Thoigian = Convert.ToDateTime("2022-03-02 15:00:00.000") , IsChecked=false ,SoluongSuatan=0},
               new CaAn {ID=3, Thoigian = Convert.ToDateTime("2022-05-04 20:00:00.000") , IsChecked=false ,SoluongSuatan=0}
           };

            SuatAnModel samodel = new SuatAnModel();
            
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
                model.ListCaAn = obj;
                list.Add(model);
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult DkiTapThe(List<DkiCaAnTapTheModel> list)
        {
            if (ModelState.IsValid)
            {
                UserSession us = (UserSession)Session["UserSession"];
                SuatAnModel samodel = new SuatAnModel();
                var time = DateTime.Now;
                for (int i = 0; i < list.Count; i++)
                {
                    if(list[i].TrangThai == true)
                    {
                        var check = samodel.InsertSuatAn(list[i].IDUser, time);
                        if (check)
                        {
                            foreach (var item in list[i].ListCaAn)
                            {
                                if (item.IsChecked && item.ID == 1 && item.SoluongSuatan > 0)
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
                Response.Write("<script>alert('Đăng kí ca ăn tập thể thành công')</script>");
                return RedirectToAction("Home", "Home"); return View();

            }
            else
            {
                ModelState.AddModelError("", "Đăng kí ca ăn thất bại!");
                return View();
            }
        }


    }
}