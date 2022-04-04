using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
{
    public class RegisterModel
    {
        [Display(Name="ID")]
      
        public string hoTen { get; set; }   
        public string username { get; set; } 
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [DataType(DataType.Password)]
        //[StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        //[RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password phải chứa: ít nhất 8 kí tự, ít nhất 1 ký tự viết hoa, 1 viết thường, 1 số và 1 ký tự đặc biệt")]
        public string password { get; set; }
        //[Display(Name = "Confirm password")]
        //[Required(ErrorMessage = "Please enter confirm password")]
        //[Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        //[DataType(DataType.Password)]
        //public string confirmPassword { get; set; }
        public bool trangThai { get; set; } = true;
        public int IDPhongBan { get; set; }

        public string quyenDangKy { get; set; }
        public int idPhanQuyen { get; set; }

       
    }
}