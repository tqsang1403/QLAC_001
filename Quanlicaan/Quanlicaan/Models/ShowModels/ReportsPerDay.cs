using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ShowModels
{
    public class ReportsPerDay
    {
        public int IDNV { get; set; }
        public string HoTen { get; set; }
        public int Soluong { get; set; }

        public int Soluongca1 { get; set; }

        public int Soluongca2 { get; set; }

        public int Soluongca3 { get; set; }

        public int Tongsoluongca3 { get; set; }

        public int Tongsoluongca2 { get; set; }

        public int Tongsoluongca1 { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime NgayDk { get; set; }

        public string TenCa { get; set; }

    }
}