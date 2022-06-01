using Quanlicaan.Models.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelsPage
{
    public class PersonalModel : NhanVien
    {
        public string TenPhongBan { get; set; }
        [DisplayName("Ngày cập nhật")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd//MM/yyyy}")]
        public DateTime time { get; set; }
    }
}