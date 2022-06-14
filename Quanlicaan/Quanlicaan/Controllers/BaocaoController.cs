using Quanlicaan.Models.DAO;
using Quanlicaan.Models.ModelsPage;
using Quanlicaan.Models.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [HttpPost]
        public ActionResult Canhan( DateTime day)
        {
            ThongkeModels thongkeModels = new ThongkeModels();
            UserSession us = (UserSession)Session["UserSession"];
            List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
            list = thongkeModels.LayDSsuatan(us.UserID, day);
            var time = DateTime.Now;
            if(list == null)
            {
                return View("Canhan");
            }
            else
            {
                return View(list);
            }
           
        }

        [HttpPost]
        public ActionResult Theothang()
        {
            return View("Baocaotheothang");
        }
    }
}