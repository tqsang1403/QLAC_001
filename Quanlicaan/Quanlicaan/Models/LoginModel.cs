using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
{
    public class LoginModel
    {
        [Required]
        public string username { set; get; }
        public string upassword { set; get; }

    }
}