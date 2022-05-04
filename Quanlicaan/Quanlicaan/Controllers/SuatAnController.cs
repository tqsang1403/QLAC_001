using Quanlicaan.Models.DAO;
using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class SuatAnController : Controller
    {
        // GET: SuatAn
        public ActionResult ShowSuatAn()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateSuatAn(SuatAn model)
        {
            
            return View();
        }
    }
}