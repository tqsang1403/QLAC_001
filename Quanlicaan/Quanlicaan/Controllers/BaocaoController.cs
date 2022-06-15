using Quanlicaan.Models.DAO;
using Quanlicaan.Models.ModelsPage;
using Quanlicaan.Models.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Quanlicaan.Controllers
{
    public class BaocaoController : Controller
    {
        // GET: Baocao
        public ActionResult Canhan()
        {

            ThongkeModels thongkeModels = new ThongkeModels();
            UserSession us = (UserSession)Session["UserSession"];
            DataSet ds = thongkeModels.LayDSsuatan(us.UserID);
            List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
            var time = DateTime.Now;
            foreach (DataRow dr in ds.Tables["Baocaocanhan"].Rows)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {


                    BaocaocanhanModelPage model = new BaocaocanhanModelPage();
                    model.IDUser = Convert.ToInt32( dr["IDnhanviendangki"]);
                    model.Hotennguoidangki = dr["Tên nhân viên đăng kí"].ToString();
                    model.LoaiSuatan = Convert.ToInt32(dr["Loaisuatan"]);
                    model.Thoigiandangki = Convert.ToDateTime(dr["Thoigiandat"]);
                    model.MaSuatan = Convert.ToInt32(dr["IDSuatAn"]);
                    model.MaCTSuatan = Convert.ToInt32(dr["ID"]);
                    model.MaCaan = Convert.ToInt32(dr["IDCaan"]);
                    model.Hotennguoidungsuatan = dr["HoTen"].ToString(); 
                    model.Soluong = Convert.ToInt32(dr["Soluong"]);
                    model.Thoigiancapnhat = Convert.ToDateTime(dr["Thoigiancapnhat"]);
                    model.Hotennguoicapnhat = dr["Tennhanviencapnhat"].ToString();
                    model.Thantien = Convert.ToInt32( dr["Soluong"]) * 15000;


                    list.Add(model);
                }
                else
                {
                    ViewData["message"] = "khong co du lieu hien thi";
                }
            }
            return View(list);

            
        }


        // tìm kiếm báo cáo theo ngày
        [HttpPost]
        public ActionResult Canhan(DateTime time)
        {
            ThongkeModels thongkeModels = new ThongkeModels();
            var day = time.ToString("yyyy-MM-dd 00:00:00");
            UserSession us = (UserSession)Session["UserSession"];
            List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
            list = thongkeModels.LayDSsuatan(us.UserID, day);
           // var time = DateTime.Now;
            if (list == null)
            {
                return View("Canhan");
            }
            else
            {
                return View(list);
            }

        }


        // thống kê suất ăn cá nhân theo tháng
        [HttpPost]
        public ActionResult Thongketheothang(DateTime month)
        {

            // lấy ra ngày đầu tiên của tháng
            DateTime dtResult2 = month;
            dtResult2 = dtResult2.AddDays((-dtResult2.Day) + 1);
            var FistDayOfMonth = dtResult2.ToString("yyyy-MM-dd 00:00:00");


            // lấy ngày cuối cùng của tháng
            DateTime dtResult = month;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            var EndDayOfMonth = dtResult.ToString("yyyy-MM-dd 23:59:59");


           
            ThongkeModels thongkeModels = new ThongkeModels();
            UserSession us = (UserSession)Session["UserSession"];
            List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
            list = thongkeModels.LayDSsuatan(us.UserID, FistDayOfMonth, EndDayOfMonth);
            // var time = DateTime.Now;
            if (list == null)
            {
                return View("Canhan");
            }
            else
            {
                return View("Canhan",list);
            }

        }



        ///// báo cáo thống kê admin 
        public ActionResult Baocaotheongay()
        {

            ThongkeModels thongkeModels = new ThongkeModels();
            UserSession us = (UserSession)Session["UserSession"];
            List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
            string firstday = null;
            string endday = null;
            list = thongkeModels.ThongkesuatanTheongay( firstday,endday);            
            return View(list);
        }


        // báo cáo thống kê admin tìm kiếm theo ngày
        [HttpPost]
        public ActionResult Baocaotheongay(DateTime fistDay, DateTime endDay)
        {
            ThongkeModels thongkeModels = new ThongkeModels();
            UserSession us = (UserSession)Session["UserSession"];
            List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
            var sfirstday = fistDay.ToString("yyyy-MM-dd 00:00:00");
            var sendday = endDay.ToString("yyyy-MM-dd 23:59:59");
            list = thongkeModels.ThongkesuatanTheongay(sfirstday, sendday);
            
            return View(list);
        }



        public ActionResult Baocaotheothang()
        {
            // lấy ra ngày đầu tiên của tháng hiện tại
            DateTime dtResult2 = DateTime.Now;
            dtResult2 = dtResult2.AddDays((-dtResult2.Day) + 1);
            var FistDayOfMonth = dtResult2.ToString("yyyy-MM-dd 00:00:00");


            // lấy ngày cuối cùng của tháng hiện tại
            DateTime dtResult = DateTime.Now;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            var EndDayOfMonth = dtResult.ToString("yyyy-MM-dd 23:59:59");

            ThongkeModels thongkeModels = new ThongkeModels();
            UserSession us = (UserSession)Session["UserSession"];
            List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
            list = thongkeModels.ThongkesuatanTheothang(FistDayOfMonth, EndDayOfMonth);

            return View(list);

        }



        [HttpPost]
        public ActionResult Baocaotheothang( DateTime month)
        {
                // lấy ra ngày đầu tiên của tháng
                DateTime dtResult2 = month;
                dtResult2 = dtResult2.AddDays((-dtResult2.Day) + 1);
                var FistDayOfMonth = dtResult2.ToString("yyyy-MM-dd 00:00:00");


                // lấy ngày cuối cùng của tháng
                DateTime dtResult = month;
                dtResult = dtResult.AddMonths(1);
                dtResult = dtResult.AddDays(-(dtResult.Day));
                var EndDayOfMonth = dtResult.ToString("yyyy-MM-dd 23:59:59");

                ThongkeModels thongkeModels = new ThongkeModels();
                List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
                list = thongkeModels.ThongkesuatanTheothang(FistDayOfMonth, EndDayOfMonth);

                return View(list);

        }
    }
}