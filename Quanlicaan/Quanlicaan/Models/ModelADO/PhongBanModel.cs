using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Models.ModelADO
{
    public class PhongBanModel
    {
      
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Nhap ten phòng ban")]
        public IEnumerable<SelectListItem> ListPB { get; set; }
        public string TenPB { get; set; }
        
    }
}