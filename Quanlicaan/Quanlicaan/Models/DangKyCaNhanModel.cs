using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
{
    public class DangKyCaNhanModel
    {
        public string hoTen { get; set; }   
        public string phongBan { get; set; }
        public DateTime ngayDK { get; set; }
        public int SLCa1 { get; set; }  
        public int SLCa2 { get; set; }
        public int SLCa3 { get; set; }
        public DangKyCaNhanModel()
        {
            var info = (UserLoginModel)Session["UserSession"];
        }
    }
}