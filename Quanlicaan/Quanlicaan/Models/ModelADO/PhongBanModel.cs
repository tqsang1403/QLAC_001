using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Models.ModelADO
{
    public class PhongBanModel
    {
        public List<SelectListItem>PhongBan{ get; set; }

        [Key]
        public int ID { get; set; }

        [Required]
        public string TenPB { get; set; }

        

    }
}