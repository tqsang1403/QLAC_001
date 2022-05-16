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
    public class ReportsPerDayController : Controller
    {
        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");
        // GET: ReportsPerDay
        public ActionResult ReportPerDay(DateTime? time)
        {
            string tm = DateTime.Today.ToString("dd-mm-yyyy");
            tm = Convert.ToString(time);

            // GET: ReportPerMonth
          
                if (!string.IsNullOrEmpty(Convert.ToString(time)) )
                {

                    string query = "Select ChiTietSuatAn.Soluong, NhanVien.*,SuatAn.*,CaAn.* from ChiTietSuatAn full join NhanVien on ChiTietSuatAn.IDUser = NhanVien.ID join SuatAn on NhanVien.ID = SuatAn.IDUser join CaAn on ChiTietSuatAn.IDCaan = CaAn.ID where ChiTietSuatAn.Soluong > 0 and (convert(varchar(10), SuatAn.Thoigiandat , 105)) = '" + time + " '  ";
                    command = new SqlCommand(query, conn);

                    conn.Open();

                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    List<ReportsPerDay> lc = new List<ReportsPerDay>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lc.Add(new ReportsPerDay
                        {
                            IDNV = Convert.ToInt32(dr["IDUser"]),
                            HoTen = Convert.ToString(dr["HoTen"]),
                            TenCa = Convert.ToString(dr["TenCa"]),
                            Soluong = Convert.ToInt32(dr["Soluong"]),
                            NgayDk = Convert.ToDateTime(dr["Thoigiandat"])



                        });


                    }

                    conn.Close();
                    ModelState.Clear();

                    return View(lc);
                }
                else
                {

                    string query = "Select ChiTietSuatAn.Soluong, NhanVien.*,SuatAn.*,CaAn.* from ChiTietSuatAn full join NhanVien on ChiTietSuatAn.IDUser = NhanVien.ID join SuatAn on NhanVien.ID = SuatAn.IDUser join CaAn on ChiTietSuatAn.IDCaan = CaAn.ID where ChiTietSuatAn.Soluong > 0 ";
                    command = new SqlCommand(query, conn);

                    conn.Open();

                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    List<ReportsPerDay> lc = new List<ReportsPerDay>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lc.Add(new ReportsPerDay
                        {
                            IDNV = Convert.ToInt32(dr["IDUser"]),
                            HoTen = Convert.ToString(dr["HoTen"]),
                            TenCa = Convert.ToString(dr["TenCa"]),
                            Soluong = Convert.ToInt32(dr["Soluong"]),
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