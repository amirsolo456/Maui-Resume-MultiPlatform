using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui.Shared.Core.Entities.ToolbarData
{
    public class FilterInfo
    {
        public string Title { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
        public string Type { get; set; } = "text"; // text, number, date, dropdown
        public List<string>? Values { get; set; } // برای dropdown
    }
}
