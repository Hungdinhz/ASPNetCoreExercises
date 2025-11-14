using System.ComponentModel.DataAnnotations;

namespace pdh_Day12_Lab2.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "Họ và Tên là bắt buộc")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải từ 4 đến 100 ký tự")] // Yêu cầu 4
        public string? Name { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public Gender Gender { get; set; }

        [Display(Name = "Ngành học")]
        [Required(ErrorMessage = "Vui lòng chọn ngành học")]
        public Branch Branch { get; set; }

        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Địa chỉ email phải có đuôi @gmail.com")]
        public string? Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
                         ErrorMessage = "Mật khẩu phải từ 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt")]
        public string? Password { get; set; }

        [Display(Name = "Hệ chính quy")]
        public bool IsRegular { get; set; }

        [Display(Name = "Địa chỉ")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string? Address { get; set; }

        [Display(Name = "Ngày sinh")]
        [Range(typeof(DateTime), "1/1/1963", "12/31/2005", ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        public DateTime DateOfBorth { get; set; }

        [Display(Name = "Điểm")]
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0")]
        public double? Diem { get; set; } // Dùng double? (nullable) để [Required] validate chính xác
    }
}