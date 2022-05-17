using Quanlicaan.Models.Session;
using Quanlicaan.Models.ShowModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home(string thongbao)
        {
            ViewData["message"] = thongbao;
            return View();
        }
        public ActionResult Home2(string thongbao)
        {
            
            ViewData["message"] = thongbao;

            ChiTietCaAnModel ct = new ChiTietCaAnModel();
            userSession us = (userSession)Session["user"];
            DataSet ds = ct.TodayRegist(us.ID);
            List<ChiTietCaAnModel> list = new List<ChiTietCaAnModel>();
            var time = DateTime.Now;
            foreach (DataRow dr in ds.Tables["CTtoday"].Rows)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {

                    ChiTietCaAnModel model = new ChiTietCaAnModel();
                    model.TenCaAn = dr["TenCa"].ToString();
                  
                    model.Soluong = Convert.ToInt32(dr["Soluong"]);
                    model.NgayDk = Convert.ToDateTime(dr["Thoigiandat"]);

                    list.Add(model);
                }
                else
                {
                    ViewData["message"] = "khong co du lieu hien thi";
                }
            }
            return View(list);

        }
    }
}