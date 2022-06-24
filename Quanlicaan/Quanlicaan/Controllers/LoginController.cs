
using Quanlicaan.Models.Checking;
using Quanlicaan.Models.ModelADO;
using Quanlicaan.Models.Models._2;
using Quanlicaan.Models.Session;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Quanlicaan.Controllers
{
    public class LoginController : Controller
    {
        string connectionString = @"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True";

        // GET: Login
        [HttpGet]
        public ActionResult Login(string thongbao)
        {
            ViewData["message"] = thongbao;
            return View();
        }
        [HttpPost]
        public ActionResult DangNhapHeThong(string username, string password)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            {
                int trangthaihd = 1;
                int trangthaivohieuhoa = 0;
                string Thongbao = "";
                //kiem tra ten dang nhap va mat khau ok
                string sqlQuery = "select * from NhanVien join PhongBan on NhanVien.IDPhongBan = PhongBan.ID join Roles on NhanVien.IDRole = Roles.ID where username ='" + username + "' and upassword = '" + password + "' and trangthai = '"+trangthaihd+"'";

                
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                userSession us = new userSession();

                conn.Open();
                cmd.Connection = conn;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    us.HoTen = dr["HoTen"].ToString();
                    us.ID = Convert.ToInt32(dr["ID"]);
                    us.IDRole = Convert.ToInt32(dr["IDRole"]);
                    us.IDPhongBan = Convert.ToInt32(dr["IDPhongBan"]);
                    us.RoleRegist = dr["RoleRegist"].ToString();
                    us.PhongBan = dr["TenPB"].ToString();
                    us.SDT = dr["SDT"].ToString();
                    us.DiaChi = dr["DiaChi"].ToString();
                    us.username = dr["username"].ToString();
                    us.upassword = dr["upassword"].ToString();
                    us.trangthai = Convert.ToBoolean(dr["trangthai"]);
                    us.GioiTinh = Convert.ToBoolean(dr["GioiTinh"]);
                    us.ChucVu = dr["ChucVu"].ToString();
                    us.QuyenTruyCap = dr["URole"].ToString();

                    Session["user"] = us;

                    conn.Close();

                    Thongbao = "Đăng nhập thành công";
                    TempData["message"] = "Dang nhap thanh cong";

                    return RedirectToAction("Home2", "Home", new { Thongbao });


                }
               
                else
                {
                    Thongbao = "Sai tên đăng nhập hoặc mật khẩu / Tài khoản bị vô hiệu hoá";
                    conn.Close();
                    return RedirectToAction("Login", "Login", new { Thongbao });



                    //return RedirectToAction("Index", new { thongBao = "tên đăng nhập và mật khẩu không đúng" });
                }



            }


        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }

        public ActionResult GetUsername()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string qr = "select username from NhanVien";
                SqlCommand sqlcm = new SqlCommand(qr, conn);
                SqlDataAdapter sda = new SqlDataAdapter(sqlcm);
                DataSet dss = new DataSet();
                sda.Fill(dss);
                List<userCheck> list = new List<userCheck>();
                foreach (DataRow dr in dss.Tables[0].Rows)
                {
                    if (dss.Tables[0].Rows.Count != 0)
                    {
                        list.Add(new userCheck
                        {
                            usernamee = Convert.ToString(dr["username"])

                        });
                    }
                    else
                    {
                        ViewBag.Message = "k co";
                    }

                }
            }
            return View();
        }

        public ActionResult RegistEmp(string thongbao)
        {
            ViewData["message"] = thongbao;
            var pb = new PhongBanModels();
            DataSet ds = pb.getAllPhongBan();
            ViewBag.PhongBan = ds.Tables["PhongBan"];


            return View(new NhanVienModel());

        }
        [HttpPost]
        public ActionResult RegistEmp(NhanVienModel nhanvienModel)
        {
            string thongbao = "";
            var pb = new PhongBanModels();
            DataSet ds = pb.getAllPhongBan();
            ViewBag.PhongBan = ds.Tables["PhongBan"];



            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (nhanvienModel.upassword == nhanvienModel.Retypeupassword)
                {
                    try
                    {

                        conn.Open();
                        string query = "insert into NhanVien(HoTen,GioiTinh,DiaChi,SDT, IDPhongBan,IDRole, ChucVu, username, upassword, RoleRegist) values(@HoTen, @GioiTinh, @DiaChi,@SDT, @IDPhongBan,'2', 'Nhân Viên', @username, @upassword, 'Cá nhân')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@HoTen", nhanvienModel.HoTen);
                        cmd.Parameters.AddWithValue("@GioiTinh", nhanvienModel.GioiTinh);
                        cmd.Parameters.AddWithValue("@DiaChi", nhanvienModel.DiaChi);
                        cmd.Parameters.AddWithValue("@SDT", nhanvienModel.SDT);
                        cmd.Parameters.AddWithValue("@IDPhongBan", nhanvienModel.IDPhongBan);
                        //cmd.Parameters.AddWithValue("@IDRole", nhanvienModel.IDrole);
                        //cmd.Parameters.AddWithValue("@ChucVu", nhanvienModel.ChucVu);
                        cmd.Parameters.AddWithValue("@username", nhanvienModel.username);
                        cmd.Parameters.AddWithValue("@upassword", nhanvienModel.upassword);
                        cmd.Parameters.AddWithValue("@trangthai", nhanvienModel.trangthai);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                        thongbao = "them moi thanh cong";
                    }
                    catch (System.Data.SqlClient.SqlException sqlException)
                    {
                        thongbao = "tao moi tai khoan that bai! Ten dang nhap da co nguoi dang ky !";
                        return RedirectToAction("RegistEmp", "Login", new { thongbao });
                    }
                }
                else
                {
                    thongbao = "mat khau khong trung khop";
                    return RedirectToAction("RegistEmp", "Login", new { thongbao });
                }
            }

            return RedirectToAction("Login", "Login", new { thongbao });
        }
    }
}