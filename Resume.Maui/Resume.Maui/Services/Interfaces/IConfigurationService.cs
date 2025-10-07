using Resume.Maui.Data.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui.Services.Interfaces
{
    public interface IConfigurationService
    {
        public Configuration Configuration { get; }

        public IEnumerable<Control> GetControlsConfiguration();
    }
}
