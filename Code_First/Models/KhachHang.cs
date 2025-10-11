using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First.Models
{
    public class KhachHang
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string MaKhachHang { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(100)")]
        public string HoTenKhachHang { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string MatKhau { get; set; } = string.Empty;

        [Column(TypeName = "varchar(15)")]
        public string DienThoai { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(200)")]
        public string DiaChi { get; set; } = string.Empty;
        public DateTime NgayDangKy { get; set; }

        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }

        public ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
    }
}

