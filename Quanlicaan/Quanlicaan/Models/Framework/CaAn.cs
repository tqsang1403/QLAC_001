namespace Quanlicaan.Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CaAn")]
    public partial class CaAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CaAn()
        {
            ChiTietSuatAns = new HashSet<ChiTietSuatAn>();
        }

        public int ID { get; set; }
        public DateTime Thoigian { get; set; }



      


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuatAn> ChiTietSuatAns { get; set; }

    }
}
