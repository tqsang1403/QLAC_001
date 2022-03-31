using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class PhongBan
    {
      
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Nhap ten phòng ban")]
        public string TenPB { get; set; }
        public List<PhongBan> ShowAllPhongBan { get; set; }
    }
}