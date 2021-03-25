using System;
using System.Collections.Generic;
using System.Linq;
using Gmlu.Demo.EntityFramework.Models;

namespace Gmlu.Demo.Web.Models
{
    public class StatsViewModel
    {
        public List<RaspberryStatsViewModel> Raspberrys { get; set; }

        public DateTime DateToFilter { get; set; }
    }

    public class RaspberryStatsViewModel
    {
        public IEnumerable<MeasurePoint> MeasurePoints { get; set; }

        public string[] GetDates => MeasurePoints?.Select(x => x.Date.ToString()).ToArray();
        public decimal[] GetTemp => MeasurePoints?.Where(x => x.Temp.HasValue).Select(x => x.Temp.Value).ToArray();
        public decimal[] GetHum => MeasurePoints?.Where(x => x.Humidity.HasValue).Select(x => x.Humidity.Value).ToArray();
    }
}
