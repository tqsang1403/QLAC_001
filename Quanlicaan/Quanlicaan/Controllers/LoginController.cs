
using Quanlicaan.Models.ModelADO;
using Quanlicaan.Models.Models._2;
using Quanlicaan.Models.Session;
using System;
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
                string Thongbao = "";
                //kiem tra ten dang nhap va mat khau ok
                string sqlQuery = "select * from NhanVien join PhongBan on NhanVien.IDPhongBan = PhongBan.ID where username ='" + username + "' and upassword = '" + password + "'"  ;

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
                    us.DiaChi= dr["DiaChi"].ToString() ;
                    us.username = dr["username"].ToString();
                    us.upassword = dr["upassword"].ToString();
                    us.trangthai = Convert.ToBoolean(dr["trangthai"]);
                    us.GioiTinh = Convert.ToBoolean(dr["GioiTinh"]);
                    us.ChucVu = dr["ChucVu"].ToString();

                    Session["user"] = us;

                    conn.Close();

                    Thongbao = "Dang nhap thanh cong";
                    TempData["message"] = "Dang nhap thanh cong";

                    return RedirectToAction("Home","Home",new {Thongbao});


                }

                else
                {
                    Thongbao = "Dang nhap that bai";
                    conn.Close();
                    return RedirectToAction("Login","Login", new {Thongbao});
                    


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


        public ActionResult RegistEmp()
        {
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
                try
                {
                    conn.Open();
                    string query = "insert into NhanVien(HoTen,GioiTinh,DiaChi,SDT, IDPhongBan,IDRole, ChucVu, username, upassword) values(@HoTen, @GioiTinh, @DiaChi,@SDT, @IDPhongBan,'2', @ChucVu, @username, @upassword)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HoTen", nhanvienModel.HoTen);
                    cmd.Parameters.AddWithValue("@GioiTinh", nhanvienModel.GioiTinh);
                    cmd.Parameters.AddWithValue("@DiaChi", nhanvienModel.DiaChi);
                    cmd.Parameters.AddWithValue("@SDT", nhanvienModel.SDT);
                    cmd.Parameters.AddWithValue("@IDPhongBan", nhanvienModel.IDPhongBan);
                    //cmd.Parameters.AddWithValue("@IDRole", nhanvienModel.IDrole);
                    cmd.Parameters.AddWithValue("@ChucVu", nhanvienModel.ChucVu);
                    cmd.Parameters.AddWithValue("@username", nhanvienModel.username);
                    cmd.Parameters.AddWithValue("@upassword", nhanvienModel.upassword);
                    cmd.Parameters.AddWithValue("@trangthai", nhanvienModel.trangthai);
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    thongbao = "them moi thanh cong";
                }
                catch (System.Data.SqlClient.SqlException sqlException)
                {
                    thongbao = "tao moi tai khoan that bai";
                }
            }

            return RedirectToAction("Login","Login", new {thongbao});
        }
    }
}