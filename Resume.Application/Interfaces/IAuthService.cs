using Resume.Application.Dtos.LoginAndSecurity;
using Resume.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Resume.Application.Common.Enums;

namespace Resume.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseTips> Register(RegisterUserDto model);
        Task<AuthResponseTips> Login(LoginDto loginDto);
        Task<UserToken> Refresh(RefreshTokenDto refreshToken);
        Task<AuthResponseTips> Logout(LogoutDto logoutDto);
    }
}
