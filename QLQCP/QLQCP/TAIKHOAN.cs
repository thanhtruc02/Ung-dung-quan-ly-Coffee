namespace QLQCP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        [StringLength(100)]
        public string TenUser { get; set; }

        [Required]
        [StringLength(100)]
        public string TenTK { get; set; }

        [Required]
        [StringLength(1000)]
        public string Matkhau { get; set; }

        public int LoaiTK { get; set; }
    }
}
