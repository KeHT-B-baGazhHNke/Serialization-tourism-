using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Serialization_tourism_
{
    [Serializable]
    public class Tours
    {
        public Tours() { }
        public List<Tour> TourList { get; set; } = new List<Tour>();
    }

    [Serializable]
    public class Tour
    {
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Time { get; set; }
        public string Guide { get; set; }
        public string Transport { get; set; }

        public Tour() { }
        public Tour(string Name, string Cost, string Time, string Guide, string Transport)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.Time = Time;
            this.Guide = Guide;
            this.Transport = Transport;
        }
    }
}
