using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLQCP
{
    public partial class HDContext : DbContext
    {
        public HDContext()
            : base("name=HDContext1")
        {
        }

        public virtual DbSet<BAN> BANs { get; set; }
        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<LOAITHUCUONG> LOAITHUCUONGs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THUCUONG> THUCUONGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BAN>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.BAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAITHUCUONG>()
                .HasMany(e => e.THUCUONGs)
                .WithRequired(e => e.LOAITHUCUONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUCUONG>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.THUCUONG)
                .WillCascadeOnDelete(false);
        }
    }
}
