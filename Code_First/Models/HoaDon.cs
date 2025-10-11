using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First.Models
{
    public class HoaDon
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MaHoaDon { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string MaKhachHang { get; set; } = string.Empty;

        public DateTime NgayHoaDon { get; set; }
        public DateTime? NgayNhan { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string HoTenKhachHang { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(15)")]
        public string DienThoai { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(50)")]
        public string DiaChi { get; set; } = string.Empty;

        public decimal TongTriGia { get; set; }

        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }

        public KhachHang KhachHang { get; set; } = null!;
        public ICollection<CTHoaDon> CTHoaDons { get; set; } = null!;

    }
}
