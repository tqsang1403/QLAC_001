﻿using Quanlicaan.Models.Session;
using Quanlicaan.Models.ShowModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
            

            // GET: ReportPerMonth

            if (!string.IsNullOrEmpty(Convert.ToString(time)))
            {
                timeSession tm = new timeSession();
                tm.day = time;
                

                Session["time"] = tm;
                string query = " select nv.*, sa.*, pb.*, (select sum(ct.Soluong)  from ChiTietSuatAn ct join SuatAn sa on ct.IDSuatAn = sa.ID where ct.IDUser = nv.ID and ct.IDCaan = '1' and(convert(varchar(10), sa.Thoigiandat, 101)) = '"+time + "')soluongca1 , (select sum(ct.Soluong)  from ChiTietSuatAn ct  where ct.IDCaan = '1' and(convert(varchar(10), sa.Thoigiandat, 101)) = '"+time + "' )Tongsoluongca1 , (select sum(ct.Soluong)  from ChiTietSuatAn ct join SuatAn sa on ct.IDSuatAn = sa.ID where ct.IDUser = nv.ID and ct.IDCaan = '2' and(convert(varchar(10), sa.Thoigiandat, 101)) = '"+time + "'  )soluongca2,(select sum(ct.Soluong)  from ChiTietSuatAn ct  where ct.IDCaan = '2' and(convert(varchar(10), sa.Thoigiandat, 101)) = '"+time + "' )Tongsoluongca2 ,(select sum(ct.Soluong)  from ChiTietSuatAn ct join SuatAn sa on ct.IDSuatAn = sa.ID where ct.IDUser = nv.ID and ct.IDCaan = '1002' and(convert(varchar(10), sa.Thoigiandat, 101)) = '"+time + "' )soluongca3, (select sum(ct.Soluong)  from ChiTietSuatAn ct  where ct.IDCaan = '1002' and(convert(varchar(10), sa.Thoigiandat, 101)) = '"+time + "' )Tongsoluongca3 ,(select sum(ct.Soluong)  from ChiTietSuatAn ct join SuatAn sa on ct.IDSuatAn = sa.ID where ct.IDUser = nv.ID  and(convert(varchar(10), sa.Thoigiandat, 101)) = '"+time + "' )Tongsoluong from NhanVien nv join SuatAn sa on nv.ID = sa.IDUser JOIN PhongBan pb on nv.IDPhongBan = pb.ID and(convert(varchar(10), sa.Thoigiandat, 101)) = '"+time + "'   ";
                command = new SqlCommand(query, conn);

                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                List<ReportsPerDay> lc = new List<ReportsPerDay>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (ds.Tables[0].Rows.Count != 0)
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
                timeSession tm = new timeSession();
                tm.day = time;
                Session["time"] = tm;

                //string query = "select nv.*, sa.*, pb.*, (select sum(ct.Soluong)  from ChiTietSuatAn ct join SuatAn sa on ct.IDSuatAn = sa.ID where ct.IDUser = nv.ID and ct.IDCaan = '1')soluongca1 ,(select sum(ct.Soluong)  from ChiTietSuatAn ct  where ct.IDCaan = '1' )Tongsoluongca1 ,(select sum(ct.Soluong)  from ChiTietSuatAn ct join SuatAn sa on ct.IDSuatAn = sa.ID where ct.IDUser = nv.ID and ct.IDCaan = '2' )soluongca2,(select sum(ct.Soluong)  from ChiTietSuatAn ct  where ct.IDCaan = '2' )Tongsoluongca2 ,(select sum(ct.Soluong)  from ChiTietSuatAn ct join SuatAn sa on ct.IDSuatAn = sa.ID where ct.IDUser = nv.ID and ct.IDCaan = '1002' )soluongca3, (select sum(ct.Soluong)  from ChiTietSuatAn ct  where ct.IDCaan = '1002' )Tongsoluongca3 ,(select sum(ct.Soluong)  from ChiTietSuatAn ct join SuatAn sa on ct.IDSuatAn = sa.ID where ct.IDUser = nv.ID  )Tongsoluong from NhanVien nv join SuatAn sa on nv.ID = sa.IDUser JOIN PhongBan pb on nv.IDPhongBan = pb.ID  ";
                string query = "select nv.*, pb.*, (select  (cOALESCE(sum(Soluong),0))  from ChiTietSuatAn ct  where ct.IDUser = nv.ID and ct.IDCaan = '1' and ct.Soluong >0)soluongca1 ,(select(cOALESCE(sum(Soluong), 0))  from ChiTietSuatAn ct  where ct.IDCaan = '1'  and ct.IDUser = nv.ID and ct.Soluong > 0)Tongsoluongca1 ,(select(cOALESCE(sum(Soluong), 0))  from ChiTietSuatAn ct  where ct.IDUser = nv.ID and ct.IDCaan = '2' and ct.Soluong > 0 )soluongca2,(select(cOALESCE(sum(Soluong), 0))  from ChiTietSuatAn ct  where ct.IDCaan = '2'  and ct.IDUser = nv.ID and ct.Soluong > 0 )Tongsoluongca2 ,(select(cOALESCE(sum(Soluong), 0))  from ChiTietSuatAn ct  where ct.IDUser = nv.ID and ct.IDCaan = '1002' and ct.Soluong > 0)soluongca3, (select(cOALESCE(sum(Soluong), 0))  from ChiTietSuatAn ct  where ct.IDCaan = '1002' and ct.IDUser = nv.ID and ct.Soluong > 0 )Tongsoluongca3 ,(select(cOALESCE(sum(Soluong), 0))  from ChiTietSuatAn ct  where ct.IDUser = nv.ID and ct.Soluong > 0 )Tongsoluong from NhanVien nv JOIN PhongBan pb on nv.IDPhongBan = pb.ID ";
                
                
                command = new SqlCommand(query, conn);

                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                List<ReportsPerDay> lc = new List<ReportsPerDay>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        lc.Add(new ReportsPerDay
                        {
                            //IDNV = Convert.ToInt32(dr["IDUser"]),
                            HoTen = Convert.ToString(dr["HoTen"]),
                            //TenCa = Convert.ToString(dr["TenCa"]),
                            Soluong = Convert.ToInt32(dr["Tongsoluong"]),
                            Soluongca1 = Convert.ToInt32(dr["soluongca1"]),
                            Soluongca2 = Convert.ToInt32(dr["soluongca2"]),
                            Soluongca3 = Convert.ToInt32(dr["soluongca3"]),
                            Tongsoluongca1 = Convert.ToInt32(dr["Tongsoluongca1"]),
                            Tongsoluongca2 = Convert.ToInt32(dr["Tongsoluongca2"]),
                            Tongsoluongca3 = Convert.ToInt32(dr["Tongsoluongca3"]),
                            //NgayDk = Convert.ToDateTime(dr["Thoigiandat"])
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