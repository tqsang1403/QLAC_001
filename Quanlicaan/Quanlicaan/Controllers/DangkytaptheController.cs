using Quanlicaan.Models;
using Quanlicaan.Models.ModelADO;
using Quanlicaan.Models.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class DangkytaptheController : Controller
    {
       
        public ActionResult TapThe( string Thongbao)
        {
            ViewData["message"] = Thongbao;
            List<CaAn> obj = new List<CaAn>()
           {
               new CaAn {ID=1,Thoigian = Convert.ToDateTime("2022-03-02 09:00:00.000") , IsChecked=false , SoluongSuatan=0 },
               new CaAn {ID=2, Thoigian = Convert.ToDateTime("2022-03-02 15:00:00.000") , IsChecked=false ,SoluongSuatan=0},
               new CaAn {ID=1002, Thoigian = Convert.ToDateTime("2022-05-04 20:00:00.000") , IsChecked=false ,SoluongSuatan=0}
           };

            SuatAnModels samodel = new SuatAnModels();

            userSession us = (userSession)Session["user"];
            DataSet ds = samodel.getAllNhanVienCungPhongBan(us.IDPhongBan);
            List<DangkyantaptheModel> list = new List<DangkyantaptheModel>();
            var time = DateTime.Now;
            foreach (DataRow dr in ds.Tables["DanhSachNvCungPhong"].Rows)
            {
                DangkyantaptheModel model = new DangkyantaptheModel();

                model.IDUser = Convert.ToInt32(dr["ID"]);
                model.HoTen = dr["HoTen"].ToString();
                model.PhongBan = dr["TenPB"].ToString();
                model.ngayDK = time;
                model.ListCaAn = obj;
                list.Add(model);
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult DkiTapThe(List<DangkyantaptheModel> list,DangkyantaptheModel tapthe)
        {
            var timeca1 = "09:00:00";
            var timeca23 = "15:00:00";

            var timedk = string.Format("{0:HH:mm:ss}", tapthe.ngayDK);
            int checktimeca1 = String.Compare(timedk, timeca1, comparisonType: StringComparison.OrdinalIgnoreCase);
            int checktimeca23 = String.Compare(timedk, timeca23, comparisonType: StringComparison.OrdinalIgnoreCase);
            // checktime < 0 thi time1 < time2
            String thongbao;
            if (ModelState.IsValid)
            {
                userSession us = (userSession)Session["user"];
                SuatAnModels samodel = new SuatAnModels();
                var time = DateTime.Now;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].TrangThai == true)
                    {
                        var check = samodel.InsertSuatAn(list[i].IDUser, time);
                        if (check)
                        {
                            foreach (var item in list[i].ListCaAn)
                            {
                                //check ca 1
                                if (item.IsChecked && item.ID == 1 && item.SoluongSuatan >= 0 && checktimeca1 < 0 )
                                {
                                    samodel.InsertCTSuatAn(list[i].IDUser, time, item.ID, item.SoluongSuatan);

                                }
                                else if (item.IsChecked && item.ID == 1 && item.SoluongSuatan > 0 && checktimeca1 > 0)
                                {
                                    thongbao = "Dang ky an cho ca 1 that bai! Qua thoi gian quy dinh";
                                    return RedirectToAction("Home2", "Home", new { thongbao });

                                }
                                //check ca 2
                                if (item.IsChecked && item.ID == 2 && item.SoluongSuatan >= 0 && checktimeca23 <0 )
                                {
                                    samodel.InsertCTSuatAn(list[i].IDUser, time, item.ID, item.SoluongSuatan);

                                }
                                else if (item.IsChecked && item.ID == 2 && item.SoluongSuatan >= 0 && checktimeca23 > 0)
                                {
                                    thongbao = "Dang ky an cho ca 2 that bai! Qua thoi gian quy dinh";
                                    return RedirectToAction("Home2", "Home", new { thongbao });

                                }
                                //check ca 3
                                if (item.IsChecked && item.ID == 1002 && item.SoluongSuatan >= 0 && checktimeca23 < 0 )
                                {
                                    samodel.InsertCTSuatAn(list[i].IDUser, time, item.ID, item.SoluongSuatan);

                                }
                                else if (item.IsChecked && item.ID == 1002 && item.SoluongSuatan > 0 && checktimeca23 > 0)
                                {
                                    thongbao = "Dang ky an cho ca 3 that bai! Qua thoi gian quy dinh";
                                    return RedirectToAction("Home2", "Home", new { thongbao });

                                }
                            }
                        }
                        else
                        {
                            thongbao = "Failed";
                            return View();
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
                thongbao = "Đang ký thành công!";
                return RedirectToAction("Home2", "Home", new {thongbao}); 

            }
            else
            {
                thongbao = "Đăng ký ăn thất bại!";
                return View();
            }
        }



    }
}