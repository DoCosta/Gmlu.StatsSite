using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gmlu.Demo.Web.Interfaces.Raspy.Models
{
    public class RaspyData
    {
        [JsonProperty("date")]
        public string Datum { get; set; }
        [JsonProperty("temp")]
        public string Temperatur { get; set; }
        [JsonProperty("hum")]
        public string Humidity { get; set; }
    }
}
