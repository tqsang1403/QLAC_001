using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelsPage
{
    public class DkiCaAnTapTheModel
    {
        public int IDUser { get; set; }
        public string hoTen { get; set; }
        public string phongBan { get; set; }
        [ReadOnly(true)]
        [DisplayName("ngày đăng kí")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ngayDK { get; set; }
      
        public bool TrangThai { get; set; }

        public List<CaAn> ListCaAn { get; set; }
    }
}