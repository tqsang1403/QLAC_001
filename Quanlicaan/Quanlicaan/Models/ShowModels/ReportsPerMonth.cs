using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ShowModels
{
    public class ReportsPerMonth
    {
        public int IDNV { get; set; }
        public string HoTen { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Soluong { get; set; }
     
        public DateTime NgayDk { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Thanhtien { get; set; }
        
        
        

        public string tenPB { get; set; }


    }
}