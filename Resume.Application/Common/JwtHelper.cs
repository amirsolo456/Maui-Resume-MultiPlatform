using Microsoft.Extensions.Configuration;
using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Common
{
    public static class JwtHelper
    {
        public static string GenerateToken(Person user, IConfiguration config)
        {
            // کد تولید JWT
            return "dummy-jwt-token"; // جایگزین با JWT واقعی
        }

        public static string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
