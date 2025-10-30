using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Resume.Application.Common;
using Resume.Application.Dtos.LoginAndSecurity;
using Resume.Application.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.Models.Security;
using Resume.Infrastructure.Data.DBContext;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Resume.Application.Common.Enums;

namespace Resume.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        protected readonly ResumeDbContext _context;
        protected readonly IConfiguration _config;
        public AuthService(ResumeDbContext resumeDb, IConfiguration configuration)
        {
            _context = resumeDb;
            _config = configuration;
        }
        public async Task<AuthResponseTips> Login(LoginDto loginDto)
        {
            try
            {
                // پیدا کردن کاربر با نام کاربری یا ایمیل
                var user = await _context.Persons
                    .FirstOrDefaultAsync(u => u.Username == loginDto.Username || u.Email == loginDto.Username);

                if (user == null)
                    return AuthResponseTips.InvalidEmail; // یا HasNotFound

                // بررسی پسورد
                var hash = HashPassword(loginDto.Password, user.PasswordSalt);
                if (hash != user.PasswordHash)
                    return AuthResponseTips.InvalidPassword;

                // تولید JWT و Refresh Token
                var token = JwtHelper.GenerateToken(user, _config);
                var refreshToken = JwtHelper.GenerateRefreshToken();

                // ذخیره توکن در DB
                var userToken = new UserToken
                {
                    Id = Guid.NewGuid(),
                    PersonId = user.Id,
                    Token = token,
                    RefreshToken = refreshToken,
                    ExpiryDate = DateTime.UtcNow.AddMinutes(30),
                    CreatedDate = DateTime.UtcNow,
                    IsRevoked = false
                };

                _context.UserTokens.Add(userToken);
                await _context.SaveChangesAsync();

                return AuthResponseTips.IsOk; // موفقیت
            }
            catch
            {
                return AuthResponseTips.IsFaulted;
            }
        }


        public async Task<AuthResponseTips> Logout(LogoutDto logoutDto)
        {
            try
            {
                var userToken = await _context.UserTokens.FirstOrDefaultAsync(t => t.RefreshToken == logoutDto.RefreshToken);
                if (userToken != null)
                {
                    userToken.IsRevoked = true;
                    await _context.SaveChangesAsync();
                }

                return AuthResponseTips.IsOk;
            }
            catch (Exception ex)
            {

               
            }
            return AuthResponseTips.IsFaulted;
        }

        public async Task<UserToken> Refresh(RefreshTokenDto refreshToken)
        {
            var userToken = await _context.UserTokens
               .Include(t => t.Person)
               .FirstOrDefaultAsync(t => t.RefreshToken == refreshToken.RefreshToken && !t.IsRevoked);

            if (userToken == null) return null;

            // تولید توکن جدید
            var newToken = JwtHelper.GenerateToken(userToken.Person, _config);
            var newRefreshToken = JwtHelper.GenerateRefreshToken();

            userToken.Token = newToken;
            userToken.RefreshToken = newRefreshToken;
            userToken.ExpiryDate = DateTime.UtcNow.AddMinutes(30);

            await _context.SaveChangesAsync();

            return  new UserToken()
            {
                Token = newToken,
                Person = userToken.Person,
                RefreshToken = newRefreshToken,
                ExpiryDate = userToken.ExpiryDate
            };
        }
 
        public async Task<AuthResponseTips> Register(RegisterUserDto model)
        {
            try
            {
                if (await _context.Persons.AnyAsync(p => p.Username == model.Username))
                    return AuthResponseTips.hasUsername;
                if (await _context.Persons.AnyAsync(p => p.Email == model.Email))
                    return AuthResponseTips.hasEmail;

                var salt = GenerateSalt();
                var hash = HashPassword(model.Password, salt);
                var user = new Person
                {
                    Id = Guid.NewGuid(),
                    Username = model.Username,
                    Email = model.Email,
                    FullName = model.FullName,
                    DisplayName = string.IsNullOrWhiteSpace(model.DisplayName) ? model.FullName : model.DisplayName,
                    Phone = model.Phone,
                    PasswordSalt = salt,
                    PasswordHash = hash,
                    CreatedDate = DateTime.UtcNow
                };
                _context.Persons.Add(user);
                await _context.SaveChangesAsync();
                return AuthResponseTips.IsOk;
            }
            catch (Exception ex)
            {

               
            }
            return AuthResponseTips.IsFaulted;
        }

        #region Helpers

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var combined = Encoding.UTF8.GetBytes(password + salt);
            var hash = sha256.ComputeHash(combined);
            return Convert.ToBase64String(hash);
        }

        #endregion
    }
}
