using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Gmlu.Demo.EntityFramework.Models;
using Gmlu.Demo.Web.Models;

namespace Gmlu.Demo.Web.Services
{
    public class StatsServiceLocal
        : IStatsService
    {
        public IEnumerable<MeasurePoint> GetMeasurePoints(
            Guid raspberryId,
            DateTime dateToLoad)
        {
            var result = new List<MeasurePoint>();

            var usedDate = dateToLoad.ToString("d");

            //using (var reader = new StreamReader(@"Services\" + CurrentDate.ToString("d") + ".csv"))
            using (var reader = new StreamReader(@"Services\" + usedDate + ".csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<CsvLine>();

                foreach (var record in records)
                {
                    result
                        .Add(
                            new MeasurePoint
                            {
                                //Device = "DemoRaspry1",
                                Date = record.Datum,
                                Temp = record.Temperatur,
                                Humidity = record.Humidity
                            });
                }
            }

            return result;
        }

        public class CsvLine
        {
            public DateTime Datum { get; set; }

            public decimal Temperatur { get; set; }

            public decimal Humidity { get; set; }
        }
    }
}
