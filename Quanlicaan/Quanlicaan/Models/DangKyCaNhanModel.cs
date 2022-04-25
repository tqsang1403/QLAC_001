using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Quanlicaan.Models;
namespace Quanlicaan.Models
{
    public class DangKyCaNhanModel
    {
        public string hoTen { get; set; }   
        public string phongBan { get; set; }
        [DisplayName("ngày đăng kí")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ngayDK { get; set; }
        public int SLCa1 { get; set; }  
        public int SLCa2 { get; set; }
        public int SLCa3 { get; set; }
       
    }
}