using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseSharedMauiApp();  // اینجا متد اکستنشن شما فراخوانی می‌شود
            return builder.Build();
        }
    }
}
