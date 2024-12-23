namespace GUI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHDBAN")]
    public partial class CTHDBAN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string soHDB { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string maSach { get; set; }

        [StringLength(50)]
        public string tenSach { get; set; }

        public int? donGia { get; set; }

        public int? soLuong { get; set; }

        public int? thanhTien { get; set; }
    }
}
