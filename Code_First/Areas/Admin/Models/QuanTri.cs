using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First.Areas.Admin.Models
{
    public class QuanTri
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column (TypeName = "nvarchar(100)")]
        public string TaiKhoan { get; set; } = null!;

        [Required]
        [Column (TypeName = "nvarchar(100)")]
        public string MatKhau { get; set; } = null!;

        [Column (TypeName = "tinyint")]
        public int TrangThai { get; set; }

    }
}
