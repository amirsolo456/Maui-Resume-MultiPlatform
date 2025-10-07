using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Dtos.LoginAndSecurity
{
    public class LogoutDto
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
