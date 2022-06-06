using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.Session
{
    public class userLogin
    {
        public string HoTen { get; set; }
        public int UserID { get; set; }
        public int IDPhongBan { get; set; }
        public string PhongBan { get; set; }

        [DisplayName("Password")] //makes column title not split
        [DataType(DataType.Password)]
        public string username { get; set; }
    }
}