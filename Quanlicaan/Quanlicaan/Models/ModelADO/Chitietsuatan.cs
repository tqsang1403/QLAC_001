using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class Chitietsuatan
    {
        public int ID { get; set; }

        public int IDUser { get; set; }

        public int Soluong { get; set; }

        public int? IDSuatAn { get; set; }

        public int IDCaan { get; set; }

        public DateTime Thoigiandat { get; set; }

        public virtual CaAn CaAn { get; set; }

        public virtual SuatAn SuatAn { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}