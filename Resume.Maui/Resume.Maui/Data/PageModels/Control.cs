using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Serialization;

namespace Resume.Maui.Data.PageModels
{
    public class Control
    {
        public Control()
        {
            this.IsThemable = true;
        }

        public string Name { get; set; }

        [XmlIgnore]
        public string Icon => StaticIcons.GetIcon(this.Name);

        public string DisplayName { get; set; }

        public string DescriptionHeader { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public string DocumentationURL { get; set; }

        public string FeedbackPortalUrl { get; set; }
        public bool IsThemable { get; set; }

        public List<Sample> Samples { get; set; }

        //[XmlIgnore]
        //public Configuration Configuration { get; set; }

        public string ExcludeFrom { get; set; }

        [XmlIgnore]
        public Sample StartupSample { get; set; }
    }
}
