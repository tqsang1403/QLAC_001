using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class DangkycanhanModel
    {
        public string HoTen { get; set; }

        public int IDPhongBan { get; set; }

        [DisplayName("ngày đăng kí")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ngayDK { get; set; }

        public int SLCa1 { get; set; }

        public int SLCa2 { get; set; }

        public int SLCa3 { get; set; }

        public string PhongBan { get; set; }

    }
}