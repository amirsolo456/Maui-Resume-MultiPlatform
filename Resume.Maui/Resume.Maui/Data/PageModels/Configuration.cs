using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui.Data.PageModels
{
    public class Configuration

    {
        public string SampleCodeUrl { get; set; }
        public List<Control> Controls { get; set; }
        public List<MauiHighlight> MauiHighlights { get; set; }

 

        public List<HighlightedControl> HighlightedControls { get; set; }
    }
}
