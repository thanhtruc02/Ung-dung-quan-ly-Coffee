namespace QLQCP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        [Key]
        public int MaCTHD { get; set; }

        public int MaHD { get; set; }

        public int MaTU { get; set; }

        public int Soluong { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual THUCUONG THUCUONG { get; set; }
    }
}
