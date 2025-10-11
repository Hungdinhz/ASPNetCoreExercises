using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Code_First.Models
{
    public class SanPham
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string MaSanPham { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(100)")]
        public string TenSanPham { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal DonGia { get; set; }
        public string HinhAnh { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public LoaiSanPham LoaiSanPham { get; set; }
        public ICollection<CTHoaDon> CTHoaDons { get; set; }
    }
}
