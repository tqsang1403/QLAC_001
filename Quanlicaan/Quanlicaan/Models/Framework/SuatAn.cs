namespace Quanlicaan.Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuatAn")]
    public partial class SuatAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuatAn()
        {
            ChiTietSuatAns = new HashSet<ChiTietSuatAn>();
        }

        public int ID { get; set; }

        public int? IDUser { get; set; }

        public DateTime Thoigiandat { get; set; }

        public bool Loaisuatan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuatAn> ChiTietSuatAns { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
