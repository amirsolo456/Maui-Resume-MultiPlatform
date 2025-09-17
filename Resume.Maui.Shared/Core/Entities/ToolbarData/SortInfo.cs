using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui.Shared.Core.Entities.ToolbarData;

public class SortInfo
{
    public string Title { get; set; } = string.Empty;
    public string Field { get; set; } = string.Empty;
    public bool IsDefault { get; set; } = false;
}
