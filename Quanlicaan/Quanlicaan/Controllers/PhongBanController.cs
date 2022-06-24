using PagedList;
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
        public ActionResult ShowAll(int? page)
        {

            if (page == null) page = 1;
            int pageSize = 5;
            //  Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);


            PhongbanModel pb = new PhongbanModel();
            DataSet ds = pb.getAllPhongBan();
            List<PhongBan> list = new List<PhongBan>();
            foreach(DataRow item in ds.Tables["PhongBan"].Rows)
            {
                PhongBan model = new PhongBan();
                model.ID = Convert.ToInt32(item["ID"]);
                model.TenPB = item["TenPB"].ToString();
                list.Add(model);
            }

            IPagedList<PhongBan> stu = null;
            stu = list.ToPagedList(pageNumber,pageSize);
            return View(stu);
        }

        public ActionResult AddPhongBan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhongBan( PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                PhongbanModel pb = new PhongbanModel();
                pb.addPhongBan(phongBan.TenPB);
                return RedirectToAction("ShowAll", "PhongBan");
            }
            else
            {
                return View();
            }
            
        }


        public ActionResult EditPB(int ID)
        {
            PhongbanModel pb = new PhongbanModel();
            PhongBan model = pb.getAllPhongBan(ID);
            return View(model);
        }


        [HttpPost]
        public ActionResult EditPB(PhongBan phongBanModel)
        {
            PhongbanModel pb = new PhongbanModel();
            pb.updatePhongBan(phongBanModel.TenPB, phongBanModel.ID);
            return RedirectToAction("ShowAll", "PhongBan");
        }


    }
}