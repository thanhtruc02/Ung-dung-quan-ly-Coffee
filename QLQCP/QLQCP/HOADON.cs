namespace QLQCP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
        }

        [Key]
        public int MaHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CheckOut { get; set; }

        public int MaB { get; set; }

        public int Trangthai { get; set; }

        public int? Discount { get; set; }

        public double? TongTien { get; set; }

        public virtual BAN BAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }
    }
}
