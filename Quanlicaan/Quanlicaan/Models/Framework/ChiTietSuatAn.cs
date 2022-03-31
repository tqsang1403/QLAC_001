namespace Quanlicaan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSuatAn")]
    public partial class ChiTietSuatAn
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
