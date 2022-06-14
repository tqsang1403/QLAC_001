using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelsPage
{
    public class DkiCaNhanModelPage
    {
        [ReadOnly(true)]
        public string hoTen { get; set; }
        [ReadOnly(true)]
        public string phongBan { get; set; }
        [ReadOnly(true)]
        [DisplayName("ngày đăng kí")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ngayDK { get; set; }
        public bool check1 { get; set; }
        public bool check2 { get; set; }
        public bool check3 { get; set; }
        public int SLCa1 { get; set; }
        public int SLCa2 { get; set; }
        public int SLCa3 { get; set; }


        [ReadOnly(true)]
        [DisplayName("giờ đăng kí ca 1")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime TimeCa1 { get; set; }

        [ReadOnly(true)]
        [DisplayName("giờ đăng kí ca 2")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime TimeCa2{ get; set; }

        [ReadOnly(true)]
        [DisplayName("giờ đăng kí ca 3")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime TimeCa3 { get; set; }


        public List<CaAn> ListCaAn { get; set; }


    }
}