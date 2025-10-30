using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Common
{
    public class Enums
    {
        public enum AuthResponseTips
        {
            hasEmail,
            InvalidEmail,
            hasUsername,
            InvalidUsername,
            InvalidPassword,
            InvalidToken,
            IsOk,
            IsFaulted,
        }
    }
}
