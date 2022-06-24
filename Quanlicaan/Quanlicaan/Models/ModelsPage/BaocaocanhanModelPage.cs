using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelsPage
{
    public class BaocaocanhanModelPage
    {
        public int IDUser { get; set; }
        public string Hotennguoidangki { get; set; }
        public string Hotennguoidungsuatan { get; set; }
        public int LoaiSuatan { get; set; }
        public int MaCTSuatan { get; set; }
        public int Soluong { get; set; }
        public int MaSuatan { get; set; }
        public int MaCaan { get; set; }
        public int Thantien { get; set; }
        public DateTime Thoigiandangki { get; set; }
        public DateTime Thoigiancapnhat { get; set; }
        public string Hotennguoicapnhat { get; set; }


    }
}