using Quanlicaan.DataAccess;
using Quanlicaan.DataAccessLayer;
using Quanlicaan.Models.ModelADO;
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
        db dbLayer = new db();
        public ActionResult Show()
        {

            DataSet ds = dbLayer.Show_All_PhongBan_Data();
            ViewBag.pb = ds.Tables[0];
            return View();

        }
        public ActionResult Add_PhongBan_Record()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_PhongBan_Record(PhongBanModel pb)
        {
            PhongBanModel pb2 = new PhongBanModel();
            pb2.TenPB = pb.TenPB;
            dbLayer.Add_Record(pb2);
            return RedirectToAction("Show");
        }
        public ActionResult Update_PhongBan_Record(int ID)
        {
            DataSet ds = dbLayer.Show_PhongBan_Record_ById(ID);
            ViewBag.PhongBanRecord = ds.Tables[0];
            return View();
        }
        [HttpPost]
        public ActionResult Update_PhongBan_Record(int ID, PhongBanModel pb)
        {
            PhongBanModel pb2 = new PhongBanModel();
            pb2.ID = pb.ID;
            pb2.TenPB = pb.TenPB;
            dbLayer.Update_Record(pb2);
            return RedirectToAction("Show");

        }
        public ActionResult Delete_PhongBan_Record(int ID)
        {
            try
            {
                dbLayer.Delete_PhongBan_Record(ID);
                return RedirectToAction("Show");
            }   
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        

        }

    }


}
