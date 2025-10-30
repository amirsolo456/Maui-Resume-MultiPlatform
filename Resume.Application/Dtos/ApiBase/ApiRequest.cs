using Resume.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Dtos.ApiBase
{
    public class ApiRequest<T>
    {
        public T Data { get; set; }             // داده اصلی درخواست
        public  string? Token { get; set; }      // توکن کاربر / دسترسی
        public int? PageNumber { get; set; }    // برای لیست‌ها (اختیاری)
        public int? PageSize { get; set; }      // برای لیست‌ها (اختیاری)
        public DateTime Timestamp { get; set; } // زمان ارسال درخواست
        public string? AdditionalInfo { get; set; } // فیلد اختیاری برای Metadata

        public ApiRequest(T data)
        {
            Data = data;
            Timestamp = DateTime.UtcNow;
        }
    }
}
