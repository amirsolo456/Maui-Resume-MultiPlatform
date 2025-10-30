using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Dtos.ApiBase
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }            // محتوای اصلی پاسخ
        public bool Success { get; set; }      // وضعیت موفقیت عملیات
        public string? Message { get; set; }   // پیام اختیاری (مثلاً خطا یا اطلاع)
        public DateTime Timestamp { get; set; } // زمان پاسخ
        public int? TotalCount { get; set; }    // تعداد کل آیتم‌ها (برای لیست‌ها)

        public ApiResponse(T data, bool success = true, string? message = null, int? totalCount = null)
        {
            Data = data;
            Success = success;
            Message = message;
            Timestamp = DateTime.UtcNow;
            TotalCount = totalCount;
        }
    }
}
