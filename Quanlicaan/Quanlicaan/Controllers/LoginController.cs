using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Quanlicaan.Common;
using Quanlicaan.Models;
using Quanlicaan.DataAccessLayer;
using System;


namespace Quanlicaan.Controllers

{

    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Model2"].ConnectionString);
        // GET: Login
        db dbLayer = new db();
        [HttpGet]
        public ActionResult Index(string thongBao)
        {

            ViewBag.thongBao = thongBao;
            return View();
        }
        [HttpPost]

        public ActionResult DangNhapHeThong(string username, string password)
        {
            //kiem tra ten dang nhap va mat khau ok
            string sqlQuery = "select 1 from NhanVien where username ='" + username + "' and upassword = '" + password + "'";

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.Connection = con;
          
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                Response.Write("<script>alert('Login sucess')</script>");
                UserLoginModel u = new UserLoginModel();
                var res = dbLayer.Get_User_Session(username, password);
                u.UserID = Convert.ToInt32(res.Tables[0].Rows[0]["ID"]);
                u.IDPhongBan = Convert.ToInt32(res.Tables[0].Rows[0]["IDPhongBan"]);
                u.PhongBan = Convert.ToString(res.Tables[0].Rows[0]["TenPB"]);
                u.hoTen = Convert.ToString(res.Tables[0].Rows[0]["hoTen"]);
                u.IDPhongBan = Convert.ToInt32(res.Tables[0].Rows[0]["IDPhongBan"]);
                u.username = Convert.ToString(res.Tables[0].Rows[0]["username"]);
                Session["UserSession"]= u;
                return Redirect("/Home/Index");
            }
            con.Close();
            Response.Write("<script>alert('Login fail')</script>");
            return RedirectToAction("Index", new { thongBao = "tên đăng nhập và mật khẩu không đúng" });
        }

        [HttpPost]
        public ActionResult logOut()
        {
            //Session.Clear();
            Session.RemoveAll();    
            return RedirectToAction("Index");
        }
        
    }
}