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
        public string fullname { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string idPhongBan { get; set; }
        [Required]
        public string quyenDangKy { get; set; }
        [Required]  
        public int idPhanQuyen { get; set; }
       
    }
}