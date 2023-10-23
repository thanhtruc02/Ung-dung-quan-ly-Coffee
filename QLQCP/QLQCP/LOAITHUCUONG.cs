namespace QLQCP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAITHUCUONG")]
    public partial class LOAITHUCUONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAITHUCUONG()
        {
            THUCUONGs = new HashSet<THUCUONG>();
        }

        [Key]
        public int MaLoaiTU { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoaiTU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUCUONG> THUCUONGs { get; set; }
    }
}
