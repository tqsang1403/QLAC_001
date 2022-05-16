using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Quanlicaan.Models.ShowModels;

namespace Quanlicaan.Controllers
{
    public class ReportPerMonthController : Controller
    {

        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");
        // GET: ReportPerMonth
        public ActionResult ReportPerMonth(DateTime? start, DateTime? end)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(start)) && !string.IsNullOrEmpty(Convert.ToString(end)))
                {

                string query = "SELECT   ( select sum(ChiTietSuatAn.Soluong) AS TONGCONG from ChiTietSuatAn where ChiTietSuatAn.IDUser = NhanVien.ID)Tongsoluong, SuatAn.*, NhanVien.HoTen FROM ChiTietSuatAn  full join SuatAn on ChiTietSuatAn.IDSuatAn = SuatAn.ID join NhanVien on SuatAn.IDUser = NhanVien.ID where SuatAn.Thoigiandat between '" + start + "'       and      '" + end + " '      ";
                command = new SqlCommand(query, conn);

                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                List<ReportsPerMonth> lc = new List<ReportsPerMonth>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lc.Add(new ReportsPerMonth
                    {
                        IDNV = Convert.ToInt32(dr["IDUser"]),
                        HoTen = Convert.ToString(dr["HoTen"]),
                        Soluong = Convert.ToInt32(dr["Tongsoluong"]),
                        NgayDk = Convert.ToDateTime(dr["Thoigiandat"])



                    });


                }


                conn.Close();
                ModelState.Clear();

                return View(lc);
            }
            else
            {

                string query = "SELECT   ( select sum(ChiTietSuatAn.Soluong) AS TONGCONG from ChiTietSuatAn where ChiTietSuatAn.IDUser = NhanVien.ID)Tongsoluong, SuatAn.*, NhanVien.HoTen FROM ChiTietSuatAn  full join SuatAn on ChiTietSuatAn.IDSuatAn = SuatAn.ID join NhanVien on SuatAn.IDUser = NhanVien.ID ";
                command = new SqlCommand(query, conn);

                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                List<ReportsPerMonth> lc = new List<ReportsPerMonth>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lc.Add(new ReportsPerMonth
                    {
                        IDNV = Convert.ToInt32(dr["IDUser"]),
                        HoTen = Convert.ToString(dr["HoTen"]),
                        Soluong = Convert.ToInt32(dr["Tongsoluong"]),
                        NgayDk = Convert.ToDateTime(dr["Thoigiandat"])
                    });


                }


                conn.Close();
                ModelState.Clear();

                return View(lc);
            }
        }
    }
}