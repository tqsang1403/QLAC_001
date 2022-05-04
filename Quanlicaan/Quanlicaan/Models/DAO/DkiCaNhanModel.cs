using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.DAO
{
    public class DkiCaNhanModel
    {
        [ReadOnly(true)]
        public string hoTen { get; set; }
        [ReadOnly(true)]
        public string phongBan { get; set; }
        [ReadOnly(true)]
        [DisplayName("ngày đăng kí")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ngayDK { get; set; }
        public int SLCa1 { get; set; }
        public int SLCa2 { get; set; }
        public int SLCa3 { get; set; }

        public List<CaAn> ListCaAn { get; set; }


    }
}