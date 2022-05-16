using Quanlicaan.DataAccess;
using Quanlicaan.Models.DAO;
using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class PhongBanController : Controller

    {
        public ActionResult ShowAll()
        {

            
            PhongbanModel pb = new PhongbanModel();
            DataSet ds = pb.getAllPhongBan();
            ViewBag.ListPhongBan = ds.Tables["PhongBan"];

            return View();

        }


        

    }
}