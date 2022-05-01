using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Models.ModelADO
{
    public class NhanVienModel
    {
      

        public int ID { get; set; }

        [Required]
        [StringLength(45)]
        public string HoTen { get; set; }

        [Required]
        public bool GioiTinh { get; set; }


        [Required]
        public string DiaChi { get; set; }


        [Required]
        [StringLength(10)]
        public string SDT { get; set; }

        [Required]
        public int IDPhongBan { get; set; }


        [Required]
        public int IDrole { get; set; }

        [Required]
        public string ChucVu { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string upassword { get; set; }


        [Required]
        public bool trangthai { get; set; }

        
        public string RoleRegist { get; set; }

        public int SLCa1 { get; set; }
        public int SLCa2 { get; set; }
        public int SLCa3 { get; set; }

        public virtual PhongBanModel PhongBan { get; set; }


    }
}