using Resume.Maui.Data.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui.ViewModels.BaseViews
{
    public class SampleViewModel : PageViewModel
    {
        private object content;
        private Sample example;

        public object Content
        {
            get { return this.content; }
            set { this.UpdateValue(ref this.content, value); }
        }

        public Sample Example
        {
            get { return this.example; }
            set { this.UpdateValue(ref this.example, value); }
        }
    }
}
