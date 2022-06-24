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
        public ActionResult Canhan(int? page)
        {

            if (page == null) page = 1;
            int pageSize = 5;
            //  Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

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
                    model.IDUser = Convert.ToInt32(dr["IDnhanviendangki"]);
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
                    model.Thantien = Convert.ToInt32(dr["Soluong"]) * 15000;


                    list.Add(model);
                }
                else
                {
                    ViewData["message"] = "khong co du lieu hien thi";
                }
            }

            IPagedList<BaocaocanhanModelPage> stu2 = null;
            stu2 = list.ToPagedList(pageNumber, pageSize);
            return View(stu2);


        }


        // tìm kiếm báo cáo theo ngày
        [HttpPost]
        public ActionResult Canhan(DateTime? time, int? page)
        {
            if (time == null)
            {
                time = DateTime.Now;
            }

            if (page == null) page = 1;
            int pageSize = 5;
            //  Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // chuyển dạng datetime? sang datetime
            DateTime time2 =(DateTime) time;

            ThongkeModels thongkeModels = new ThongkeModels();
            var day = time2.ToString("yyyy-MM-dd 00:00:00");

            //day = String.Format("{0:dd MM yyyy 00:00:00}", day);
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
                IPagedList<BaocaocanhanModelPage> stu2 = null;
                stu2 = list.ToPagedList(pageNumber, pageSize);
                return View(stu2);
            }


        }


        // thống kê suất ăn cá nhân theo tháng
        [HttpPost]
        public ActionResult Thongketheothang(DateTime? month, int? page)
        {

            if (month == null)
            {
                month = DateTime.Now;
            }

            if (page == null) page = 1;
            int pageSize = 5;
            //  Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // chuyển dạng datetime? sang datetime
            DateTime month2 = (DateTime)month;

            // lấy ra ngày đầu tiên của tháng
            DateTime dtResult2 = month2;
            dtResult2 = dtResult2.AddDays((-dtResult2.Day) + 1);
            var FistDayOfMonth = dtResult2.ToString("yyyy-MM-dd 00:00:00");


            // lấy ngày cuối cùng của tháng
            DateTime dtResult = month2;
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
                IPagedList<BaocaocanhanModelPage> stu2 = null;
                stu2 = list.ToPagedList(pageNumber, pageSize);
                return View("Canhan", stu2);
            }
          

        }



        ///// báo cáo thống kê admin 
        public ActionResult Baocaotheongay(int? page)
        {

            if (page == null) page = 1;
            int pageSize = 5;
            //  Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);


            ThongkeModels thongkeModels = new ThongkeModels();
            UserSession us = (UserSession)Session["UserSession"];
            List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
            string firstday = null;
            string endday = null;
            list = thongkeModels.ThongkesuatanTheongay(firstday, endday);

            IPagedList<BaocaocanhanModelPage> stu2 = null;
            stu2 = list.ToPagedList(pageNumber, pageSize);
            return View(stu2);
        }


        // báo cáo thống kê admin tìm kiếm theo ngày
        [HttpPost]
        public ActionResult Baocaotheongay(DateTime? fistDay, DateTime? endDay, int? page)
        {
            if (fistDay == null) fistDay = DateTime.Now;

            if (endDay == null) endDay = DateTime.Now;
           
            if (page == null) page = 1;
            int pageSize = 5;
            //  Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);


            // chuyển dạng datetime? sang datetime
            DateTime fistDay2 = (DateTime) fistDay;
            DateTime endDay2 = (DateTime)endDay;



            ThongkeModels thongkeModels = new ThongkeModels();
            UserSession us = (UserSession)Session["UserSession"];
            List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
            var sfirstday = fistDay2.ToString("yyyy-MM-dd 00:00:00");
            var sendday = endDay2.ToString("yyyy-MM-dd 23:59:59");
            list = thongkeModels.ThongkesuatanTheongay(sfirstday, sendday);

            IPagedList<BaocaocanhanModelPage> stu2 = null;
            stu2 = list.ToPagedList(pageNumber, pageSize);
            return View(stu2);
            
        }



        public ActionResult Baocaotheothang(int? page)
        {
           
            if (page == null) page = 1;
            int pageSize = 5;
            //  Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);


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

            IPagedList<BaocaocanhanModelPage> stu2 = null;
            stu2 = list.ToPagedList(pageNumber, pageSize);
            return View(stu2);
            
        }



        [HttpPost]
        public ActionResult Baocaotheothang(DateTime? month, int? page)
        {
            if (month == null)
            {
                month = DateTime.Now;
            }

            if (page == null) page = 1;
            int pageSize = 5;

            //  Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);


            DateTime month2 = (DateTime)month;

            // lấy ra ngày đầu tiên của tháng
            DateTime dtResult2 = month2;
            dtResult2 = dtResult2.AddDays((-dtResult2.Day) + 1);
            var FistDayOfMonth = dtResult2.ToString("yyyy-MM-dd 00:00:00");


            // lấy ngày cuối cùng của tháng
            DateTime dtResult = month2;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            var EndDayOfMonth = dtResult.ToString("yyyy-MM-dd 23:59:59");

            ThongkeModels thongkeModels = new ThongkeModels();
            List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
            list = thongkeModels.ThongkesuatanTheothang(FistDayOfMonth, EndDayOfMonth);

            IPagedList<BaocaocanhanModelPage> stu2 = null;
            stu2 = list.ToPagedList(pageNumber, pageSize);
            return View(stu2);
           

        }
    }
}