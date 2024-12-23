namespace GUI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETHDN")]
    public partial class CHITIETHDN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string soHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string maSach { get; set; }

        [StringLength(50)]
        public string tenSach { get; set; }

        public int? slNhap { get; set; }

        public virtual HDNHAP HDNHAP { get; set; }
    }
}
