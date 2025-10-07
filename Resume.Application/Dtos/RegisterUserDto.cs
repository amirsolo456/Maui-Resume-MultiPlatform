using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(20, MinimumLength = 6, ErrorMessage = "رمز عبور باید بین ۶ تا ۱۰۰ کاراکتر باشد")]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن یکسان نیست")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
