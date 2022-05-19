using Quanlicaan.Models.ModelADO;
using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ShowModels
{
    public class userModel
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


        public string PhongBan { get; set; }


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

        public string RoleRegist { get; set; }

        [Required]
        public bool trangthai { get; set; }
        public string QuyenTruyCap { get; set; }




    }
}