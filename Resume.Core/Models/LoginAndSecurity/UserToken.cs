using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.Models.Security
{
    public class UserToken
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }           // Foreign key
        public Person Person { get; set; } = null!; // Navigation property

        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsRevoked { get; set; } = false;
    }
}
