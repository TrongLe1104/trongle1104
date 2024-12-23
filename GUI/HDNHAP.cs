namespace GUI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HDNHAP")]
    public partial class HDNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HDNHAP()
        {
            CHITIETHDNs = new HashSet<CHITIETHDN>();
        }

        [Key]
        [StringLength(6)]
        public string soHD { get; set; }

        [Required]
        [StringLength(6)]
        public string maNV { get; set; }

        public DateTime? ngayNhap { get; set; }

        [StringLength(6)]
        public string maNCC { get; set; }

        public int? giaNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHDN> CHITIETHDNs { get; set; }
    }
}
