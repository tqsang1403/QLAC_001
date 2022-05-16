using Quanlicaan.Models.DAO;
using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class CaAnController : Controller
    {
        // GET: CaAn
        public ActionResult ShowCaAn()
        {
            CaAnModel caAnModel = new CaAnModel();
            List<CaAn> model = new List<CaAn>();
            model = caAnModel.GetCaAns();
            return View( model);
        }

     
    }
}
