using Quanlicaan.Models.ModelADO;
using Quanlicaan.Models.Session;
using Quanlicaan.Models.ShowModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");
            {

                
                string sqlQuery = "  SELECT ca.TenCa,CONVERT(VARCHAR(8),ca.Thoigian,108)thoigian from CaAn ca";


                SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                CaAnSession ca = new CaAnSession();

                conn.Open();
                cmd.Connection = conn;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    ca.tenCa = dr["TenCa"].ToString();
                    ca.thoigian = Convert.ToDateTime(dr["thoigian"]);


                    Session["CaAn"] = ca;

                    conn.Close();
                }
            }

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
                    model.IDCaAn = Convert.ToInt32(dr["IDCaan"]);
                    model.IDUSer = Convert.ToInt32(dr["IDUser"]);
                    model.Soluong = Convert.ToInt32(dr["Soluong"]);
                    model.NgayDk = Convert.ToDateTime(dr["Thoigiandat"]);
                    model.TenCaAn = Convert.ToString(dr["TenCa"]);
                    list.Add(model);
                }
                else
                {
                    ViewData["message"] = "khong co du lieu hien thi";
                }
            }
            return View(list);

        }


        public ActionResult EditDkiCaanCanhan()
        {
            userSession us = (userSession)Session["user"];
            EditPersonalMeal edit = new EditPersonalMeal();
            List<EditPersonalMeal> list = edit.getAllSuatAnDangKi(us.ID);
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

        [HttpPost]
        public ActionResult EditDkiCaanCanhan(List<EditPersonalMeal> model)
        {
            EditPersonalMeal suatAnModel = new EditPersonalMeal();
            for (int i = 0; i < model.Count; i++)
            {
                suatAnModel.UpDateChiTietSuatAn(model[i].IDUSer, model[i].IDChiTietSuatAn, model[i].Soluong);
            }
            ViewBag.updateSucess = "Bạn đã cập nhật thành công";
            return RedirectToAction("Home2", "Home");
        }



        [HttpGet]
        public ActionResult Delete(int ID)
        {
            EditPersonalMeal suatAnModel = new EditPersonalMeal();
            suatAnModel.DeleteChiTietSuatAn(ID);
            return RedirectToAction("Home2", "Home");
        }


    }
}