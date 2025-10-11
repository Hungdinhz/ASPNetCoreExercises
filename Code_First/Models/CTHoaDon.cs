using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First.Models
{
    public class CTHoaDon
    {
        [Key]
        public int ID { get; set; }

        public int HoaDonID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuongMua { get; set; }
        public decimal DonGiaMua { get; set; }
        public decimal ThanhTien { get; set; }

        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }

        public HoaDon HoaDon { get; set; } = null!;
        public SanPham SanPham { get; set; } = new SanPham();

    }
}
