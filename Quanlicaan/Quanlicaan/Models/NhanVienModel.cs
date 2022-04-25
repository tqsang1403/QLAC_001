using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
{
    public class NhanVienModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string hoTen { get; set; }
        [Required]
        public int IDPhongBan { get; set; }

        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int IDRole { get; set; }
        [Required]
        public string quyen { get; set; }
        [Required]
        public Boolean trangThai { get; set; }
        public int SLCa1 { get; set; }
        public int SLCa2 { get; set; }
        public int SLCa3 { get; set; }



    }
}