using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui.Data.PageModels
{
    public class Sample
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }
        public string CodeUrl { get; set; }

        public string Page { get; set; }

        public string Description { get; set; }

        public string ExcludeFrom { get; set; }

        public string ControlName { get; set; }

        public bool IsConfigurable { get; set; }

        public bool IsThemable { get; set; }
    }
}
