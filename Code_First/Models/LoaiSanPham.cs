using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string MaLoai { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(100)")]
        public string TenLoai { get; set; } = string.Empty;

        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }

        
        public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }
}
