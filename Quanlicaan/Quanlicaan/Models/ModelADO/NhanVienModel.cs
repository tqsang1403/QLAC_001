using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class NhanVienModel
    {
      

        public int ID { get; set; }

        [Required(ErrorMessage ="Không được để trống ")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Không được để trống ")]
        public bool GioiTinh { get; set; }


        [Required(ErrorMessage = "Không được để trống ")]
        public string DiaChi { get; set; }


        [Required(ErrorMessage = "Không được để trống ")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Không được để trống ")]
        public int IDPhongBan { get; set; }


        [Required(ErrorMessage = "Không được để trống ")]
        public int IDrole { get; set; }

        [Required(ErrorMessage = "Không được để trống ")]
        public string ChucVu { get; set; }

        [Required(ErrorMessage = "Không được để trống ")]
        public string username { get; set; }

        [Required(ErrorMessage = "Không được để trống ")]
        public string upassword { get; set; }


        [Required(ErrorMessage = "Không được để trống ")]
        public bool trangthai { get; set; }

        public string RoleRegist { get; set; }


    }
}