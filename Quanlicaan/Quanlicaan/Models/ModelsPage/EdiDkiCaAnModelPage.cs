using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelsPage
{
    public class EdiDkiCaAnModelPage
    {
        public int IDUser { get; set; }
        public string hoTen { get; set; }
        [ReadOnly(true)]
        [DisplayName("ngày đăng kí")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ngayDK { get; set; }
        public int IDChiTietSuatAn { get; set; }
        public int IDSuatAn { get; set; }
        public int IDCaAn { get; set; }
        public int Soluong { get; set; }

        [ReadOnly(true)]
        [DisplayName("giờ đăng kí ca 1")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime TimeCa1 { get; set; }

        [ReadOnly(true)]
        [DisplayName("giờ đăng kí ca 2")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime TimeCa2 { get; set; }

        [ReadOnly(true)]
        [DisplayName("giờ đăng kí ca 3")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime TimeCa3 { get; set; }


    }
}