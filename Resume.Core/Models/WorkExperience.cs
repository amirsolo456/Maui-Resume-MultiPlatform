using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.Models
{
    public class WorkExperience
    {
        /// <summary>
        /// شناسه‌ها (Id) از نوع Guid استفاده شده‌اند به جای int.
        /// 
        /// مزایا:
        /// 1. یکتا بودن در سطح جهانی (Global Unique)
        ///    - هر Guid به صورت تصادفی تولید می‌شود و احتمال تکرار بسیار کم است.
        ///    - مناسب برای همگام‌سازی داده‌ها بین چند دیتابیس یا سرویس.
        /// 
        /// 2. مناسب برای سیستم‌های توزیع‌شده (Distributed Systems)
        ///    - چند سرویس جداگانه می‌توانند بدون هماهنگی رکورد ایجاد کنند.
        ///    - احتمال برخورد صفر است.
        /// 
        /// 3. ساخت آسان بدون نیاز به دیتابیس
        ///    - با Guid.NewGuid() می‌توان قبل از Insert رکورد، شناسه‌ای یکتا داشت.
        ///    - مناسب برای تولید داده‌های موقت یا Seed داده‌ها.
        /// 
        /// معایب احتمالی:
        /// - حجم بیشتر نسبت به int (16 بایت در مقابل 4 بایت) و کمی سنگین‌تر شدن ایندکس‌ها.
        /// - خوانایی کمتر در Debug و لاگ‌ها.
        /// - ترتیب تصادفی رکوردها در Clustered Index (قابل کاهش با NEWSEQUENTIALID() در SQL).
        /// 
        /// جمع‌بندی:
        /// - برای پروژه‌های کوچک و متوسط مثل این رزومه، Guid کاملاً مناسب است.
        /// - آماده برای گسترش به سیستم‌های توزیع‌شده و مهاجرت‌های آینده.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Company { get; set; } = "";
        public string Position { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; } = "";

        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
        public Guid? NavigationItemId { get; set; } // ← nullable
        public NavigationItem? NavigationItem { get; set; }
    }
}
