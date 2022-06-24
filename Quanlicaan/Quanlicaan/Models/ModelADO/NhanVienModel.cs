using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

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


        [DisplayName("Password")] //makes column title not split
        [DataType(DataType.Password)]
        [Required]
        public string upassword { get; set; }



        [NotMapped]
        [Required(ErrorMessage = "Confirm Password required")]
        [Compare("upassword", ErrorMessage = "Password doesn't match.")]
        public string Retypeupassword { get; set; }

        public string OldPass { get; set; }


        [Required]
        public bool trangthai { get; set; }

        
        public string RoleRegist { get; set; }


        public virtual PhongBanModel PhongBan { get; set; }



        public string TenPB { get; set; }

        public List<NhanVienModel> listnvien { get; set; }
    }
}