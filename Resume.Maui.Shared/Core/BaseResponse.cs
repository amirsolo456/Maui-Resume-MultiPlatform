using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui.Shared.Core
{
    public class BaseResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int totalCoutn { get; set; }
        public Message message { get; set; }
    }
 
    public class Message
    {
        public string Result { get; set; }
        public int Status { get; set; }
    }
}
