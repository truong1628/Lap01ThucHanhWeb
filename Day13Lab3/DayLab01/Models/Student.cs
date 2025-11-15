using System.ComponentModel.DataAnnotations;

namespace DayLab01.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Họ tên chỉ được chứa chữ cái và khoảng trắng")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email không được để trống")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi @gmail.com")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}$",
            ErrorMessage = "Mật khẩu phải có chữ hoa, thường, số và ký tự đặc biệt")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng chọn ngành")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public Gender? Gender { get; set; }

        public bool IsRegular { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1900-01-01", "2025-12-31",
            ErrorMessage = "Năm sinh phải từ 1900 đến 2025")]
        public DateTime DateOfBorth { get; set; }

        [Required(ErrorMessage = "Điểm không được để trống")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải từ 0.0 đến 10.0")]
        [RegularExpression(@"^10(\.0?)?$|^[0-9](\.\d)?$",
            ErrorMessage = "Điểm chỉ được tối đa 1 chữ số thập phân (vd: 8, 9.5, 10.0)")]
        public double? Score { get; set; }

        public string? Avatar { get; set; }

    }   


    
}
