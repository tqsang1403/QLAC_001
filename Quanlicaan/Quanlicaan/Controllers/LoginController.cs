using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
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