using System;
using System.Collections.Generic;
using System.Linq;

namespace Gmlu.Demo.Web.Models
{
    public class StatsViewModel
    {
        public IEnumerable<MeasurePoint> MeasurePoints { get; set; }

        public string[] GetDates => MeasurePoints.Select(x => x.Date.ToString()).ToArray();
        public decimal[] GetTemp => MeasurePoints.Select(x => x.Temp).ToArray();
        public decimal[] GetHum => MeasurePoints.Select(x => x.Humidity).ToArray();

        public DateTime DateToFilter { get; set; }
    }
}
