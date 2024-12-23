using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GUI
{
    public partial class ModelHoaDon : DbContext
    {
        public ModelHoaDon()
            : base("name=ModelHoaDon1")
        {
        }

        public virtual DbSet<CTHDBAN> CTHDBANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
