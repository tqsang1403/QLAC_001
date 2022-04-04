using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Quanlicaan.Controllers

{

    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Model2"].ConnectionString);
        // GET: Login
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
                Session["username"] = username;
                return Redirect("/Home/Index");


            }
            //if (username == "root" && password == "123")
            //{
            //    // chuyen huong sang trang login tai khoan 

            //}
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(LoginModel model)
        //{

        //    if( ModelState.IsValid)
        //    {
        //        SessionHelper.SetSession(new UserSession() { username = model.username });
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
        //    }
        //    return View(model);
        //}
    }
}