using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Quanlicaan.Models.ShowModels;
using System.Windows.Forms;
using Quanlicaan.Models.Session;

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
                //select nv.*, sa.Thoigiandat, (select sum(ct.Soluong)  from ChiTietSuatAn ct where ct.IDUser = nv.ID) from NhanVien nv join SuatAn sa on nv.ID = sa.IDUser where sa.Thoigiandat between between '" + start + "'       and      '" + end + " ' 
                //string query = "SELECT   ( select sum(ChiTietSuatAn.Soluong) AS TONGCONG from ChiTietSuatAn where ChiTietSuatAn.IDUser = NhanVien.ID)Tongsoluong, SuatAn.*, NhanVien.HoTen FROM ChiTietSuatAn  full join SuatAn on ChiTietSuatAn.IDSuatAn = SuatAn.ID join NhanVien on SuatAn.IDUser = NhanVien.ID where SuatAn.Thoigiandat between '" + start + "'       and      '" + end + " '      ";
                //string query = "select nv.*, sa.*, pb.*,(select sum(ct.Soluong)  from ChiTietSuatAn ct where ct.IDUser = nv.ID and sa.Thoigiandat between '" + start + "'  and   '" + end + " ' ")Tongsoluong from NhanVien nv join SuatAn sa on nv.ID = sa.IDUser JOIN PhongBan pb on nv.IDPhongBan = pb.ID where sa.Thoigiandat between '" + start + "' and   '" + end + "'  " ;

                timeSession tm = new timeSession();


                String query = "select nv.*, sa.*, pb.*,(select sum(ct.Soluong)  from ChiTietSuatAn ct where ct.IDUser = nv.ID and sa.Thoigiandat between '" + start + "'  and  '" + end + "' + '12:00:00' )Tongsoluong from NhanVien nv join SuatAn sa on nv.ID = sa.IDUser JOIN PhongBan pb on nv.IDPhongBan = pb.ID where sa.Thoigiandat between '" + start + "'  and  '" + end + "' + '12:00:00' ";



                command = new SqlCommand(query, conn);

                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                tm.startt = start;
                tm.endd = end;

                Session["time"] = tm;

                sda.Fill(ds);
                List<ReportsPerMonth> lc = new List<ReportsPerMonth>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        lc.Add(new ReportsPerMonth
                        {
                            IDNV = Convert.ToInt32(dr["IDUser"]),
                            HoTen = Convert.ToString(dr["HoTen"]),
                            Soluong = Convert.ToInt32(dr["Tongsoluong"]),
                            NgayDk = Convert.ToDateTime(dr["Thoigiandat"]),
                            tenPB = Convert.ToString(dr["TenPB"]),
                            Thanhtien = (Convert.ToInt32(dr["Tongsoluong"])*15000)

                        });
                        
                    }
                    else
                    {
                        ViewBag.Message = "khong co ca an";
                    }

                }


                conn.Close();
                ModelState.Clear();

                return View(lc);
            }
            else
            {
                string query = "select nv.ID as IDNV, nv.HoTen , pb.*, (select  (cOALESCE(sum(Soluong),0))  from ChiTietSuatAn ct  where ct.IDUser = nv.ID and ct.IDCaan = '1' and ct.Soluong >0)soluongca1 ,(select(cOALESCE(sum(Soluong), 0))  from ChiTietSuatAn ct  where ct.IDUser = nv.ID and ct.IDCaan = '2' and ct.Soluong > 0)soluongca2,(select(cOALESCE(sum(Soluong), 0))  from ChiTietSuatAn ct  where ct.IDUser = nv.ID and ct.IDCaan = '1002' and ct.Soluong > 0)soluongca3, (select(cOALESCE(sum(Soluong), 0))  from ChiTietSuatAn ct  where ct.IDUser = nv.ID and ct.Soluong > 0 )Tongsoluong,(select(cOALESCE(sum(Soluong), 0)) * 15000 from ChiTietSuatAn ct  where ct.IDUser = nv.ID )as Thanhtien from NhanVien nv JOIN PhongBan pb on nv.IDPhongBan = pb.ID ";
                command = new SqlCommand(query, conn);

                conn.Open();
                timeSession tm = new timeSession();
                tm.startt = start;
                tm.endd = end;

                Session["time"] = tm;


                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                List<ReportsPerMonth> lc = new List<ReportsPerMonth>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        lc.Add(new ReportsPerMonth
                    {
                        
                        HoTen = Convert.ToString(dr["HoTen"]),
                        Soluong = Convert.ToInt32(dr["Tongsoluong"]),
                        tenPB = Convert.ToString(dr["TenPB"]), 
                        Thanhtien = (Convert.ToInt32(dr["Thanhtien"]))
                        });
                    }
                    else
                    {
                        ViewBag.Message = "khong co ca an";
                    }

                }


                conn.Close();
                ModelState.Clear();

                return View(lc);
            }
        }
    }
}