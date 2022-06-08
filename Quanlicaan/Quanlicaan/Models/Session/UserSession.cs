using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.Session
{
    public class UserSession
    {
        public string hoTen { get; set; }
        public int UserID { get; set; }
        public int IdPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public int IDRoleUser { get; set; }
        
    }
}