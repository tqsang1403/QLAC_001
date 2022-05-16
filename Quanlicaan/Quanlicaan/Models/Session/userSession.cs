using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.Session
{
    public class userSession
    {
        public int ID { get; set; }
        public string HoTen { get; set; }

        public int IDRole { get; set; }
        public string RoleRegist { get; set; }
        public int IDPhongBan { get; set; }
        public string PhongBan { get; set; }

        public string DiaChi { get; set; }


        public string username { get; set; }

        public string upassword { get; set; }
        public bool trangthai { get; set; }

        public string SDT { get; set; }

        public bool GioiTinh { get; set; }

        public string ChucVu { get; set; }


    }

}