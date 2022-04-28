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
    }
}