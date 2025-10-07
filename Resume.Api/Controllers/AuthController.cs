using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Dtos.LoginAndSecurity;
using Resume.Application.Interfaces;
using Resume.Infrastructure.Services;
using static Resume.Application.Common.Enums;

namespace Resume.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected IAuthService _context;
        public AuthController(IAuthService auth) => _context = auth;

        // POST: api/Auth/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _context.Register(model);

            return result switch
            {
                AuthResponseTips.IsOk => Ok(new { Message = "ثبت‌نام با موفقیت انجام شد" }),
                AuthResponseTips.hasUsername => BadRequest(new { Message = "نام کاربری قبلا ثبت شده" }),
                AuthResponseTips.hasEmail => BadRequest(new { Message = "ایمیل قبلا ثبت شده" }),
                _ => StatusCode(500, new { Message = "خطای سرور" })
            };
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _context.Login(model);

            return result switch
            {
                AuthResponseTips.IsOk => Ok(new { Message = "ورود موفقیت‌آمیز است" }),
                AuthResponseTips.InvalidEmail => BadRequest(new { Message = "ایمیل یا نام کاربری معتبر نیست" }),
                AuthResponseTips.InvalidPassword => BadRequest(new { Message = "رمز عبور اشتباه است" }),
                _ => StatusCode(500, new { Message = "خطای سرور" })
            };
        }

        // POST: api/Auth/Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutDto model)
        {
            var result = await _context.Logout(model);

            return result == AuthResponseTips.IsOk
                ? Ok(new { Message = "کاربر با موفقیت خارج شد" })
                : StatusCode(500, new { Message = "خطا در خروج کاربر" });
        }

        // POST: api/Auth/Refresh
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenDto model)
        {
            var token = await _context.Refresh(model);
            if (token == null)
                return Unauthorized(new { Message = "توکن نامعتبر است" });

            return Ok(new
            {
                Token = token.Token,
                RefreshToken = token.RefreshToken,
                Expiry = token.ExpiryDate
            });
        }

    }
}
