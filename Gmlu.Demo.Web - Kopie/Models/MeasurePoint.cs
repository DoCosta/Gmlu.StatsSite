using System;

namespace Gmlu.Demo.Web.Models
{
    public class MeasurePoint
    {
        public DateTime Date { get; set; }

        public decimal Temp { get; set; }

        public decimal Humidity { get; set; }

        public string Device { get; set; }
    }
}
