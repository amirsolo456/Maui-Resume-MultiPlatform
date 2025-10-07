using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Dtos.LoginAndSecurity
{
    public class RegisterUserDto
    {
        [Required, MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "نام کاربری فقط می‌تواند شامل حروف، اعداد و _ باشد")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست")]
        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        
 
        [Required, Compare("Password", ErrorMessage = "رمز عبور و تکرار آن یکسان نیست"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string DisplayName { get; set; } = string.Empty;

        [Required]
        [Phone(ErrorMessage = "شماره تماس معتبر نیست")]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;
    }
}
