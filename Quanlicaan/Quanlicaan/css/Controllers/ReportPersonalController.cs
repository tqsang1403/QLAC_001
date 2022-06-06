using Quanlicaan.Models.Session;
using Quanlicaan.Models.ShowModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Quanlicaan.Controllers
{
    public class ReportPersonalController : Controller
    {
        // GET: ReportPersonal

        string connectionString = @"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True";
        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");

  
            
        public ActionResult PersonalReport()
        {
            string thongbao = "";
            ChiTietCaAnModel ct = new ChiTietCaAnModel();
            userSession us = (userSession)Session["user"];
            DataSet ds = ct.getPersionalMeal(us.ID);
            List<ChiTietCaAnModel> list = new List<ChiTietCaAnModel>();
            var time = DateTime.Now;
            foreach (DataRow dr in ds.Tables["Baocaocanhan"].Rows)
            {
                if(ds.Tables[0].Rows.Count != 0)
                {

                    ChiTietCaAnModel model = new ChiTietCaAnModel();
                    model.TenCaAn = dr["TenCa"].ToString();
                    model.IDCaAn = Convert.ToInt32(dr["IDCaan"]);
                    model.IDSuatAn = Convert.ToInt32(dr["IDSuatAn"]);
                    model.Soluong = Convert.ToInt32(dr["Soluong"]);
                    model.NgayDk = Convert.ToDateTime(dr["Thoigiandat"]);

                    list.Add(model);
                }else
                {
                    ViewData["message"]= "khong co du lieu hien thi";
                }
            }
            return View(list);
        }
    }
}