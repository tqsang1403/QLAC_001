using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class PhongBanModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string TenPB { get; set; }

    }
}