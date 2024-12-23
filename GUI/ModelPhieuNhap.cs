using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GUI
{
    public partial class ModelPhieuNhap : DbContext
    {
        public ModelPhieuNhap()
            : base("name=ModelPhieuNhap")
        {
        }

        public virtual DbSet<CHITIETHDN> CHITIETHDNs { get; set; }
        public virtual DbSet<HDNHAP> HDNHAPs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HDNHAP>()
                .HasMany(e => e.CHITIETHDNs)
                .WithRequired(e => e.HDNHAP)
                .WillCascadeOnDelete(false);
        }
    }
}
