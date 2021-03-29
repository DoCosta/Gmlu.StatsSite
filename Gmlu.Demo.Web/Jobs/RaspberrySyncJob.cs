using Gmlu.Demo.EntityFramework.DataContext;
using Gmlu.Demo.EntityFramework.Models;
using Gmlu.Demo.Web.Interfaces.Raspy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gmlu.Demo.Web.Jobs
{
    public class RaspberrySyncJob
    {
        private readonly ILogger<RaspberrySyncJob> _logger;
        private readonly StatsContext _context;

        public RaspberrySyncJob(
            ILogger<RaspberrySyncJob> logger,
            StatsContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task Run()
        {
            _logger.LogInformation("RaspberrySyncJob started");

            // load all raspberry from database and loop
            // foreach => _context.Raspberry
            foreach (var raspy in _context.Raspberrys.AsNoTracking())
            {
                var ipaddress = raspy.IPadress;

                // Raspberry.IdAdress => $"{http://{idaddress}/}
                string url = "http://" + ipaddress + ":8080";

                // HttpClient
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // response => json
                string json = await response.Content.ReadAsStringAsync();

                // json => Deserialize to Object (Newtonsoft.Json) => JsonConverter.DeserializeObject<OBJECT>(json)
                var raspberry = JsonConvert.DeserializeObject<List<RaspyData>>(json); 

                List<RaspyData> SortedList = raspberry.OrderByDescending(o => o.Datum).ToList();

                foreach (var newMeasurePoint in SortedList)
                {
                    var date = Convert.ToDateTime(newMeasurePoint.Datum);
                    var mp = _context
                        .MeasurePoints
                        .SingleOrDefault(
                        x => x.Date == date
                          && x.Raspberry.IPadress == raspy.IPadress);

                    if (mp == null)
                    {
                        var entity = new MeasurePoint();
                        entity.MeasurePointId = Guid.NewGuid();
                        entity.Date = DateTime.Parse(newMeasurePoint.Datum);

                        entity.Humidity = Decimal.Parse(newMeasurePoint.Humidity, CultureInfo.InvariantCulture);
                        entity.Temp = Decimal.Parse(newMeasurePoint.Temperatur, CultureInfo.InvariantCulture);

                        entity.RaspberryId = raspy.RaspberryId;

                        _context.MeasurePoints.Add(entity);
                    }
                }   
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Failed during save MeasurePoints", ex);
                throw;
            }

            _logger.LogInformation("RaspberrySyncJob stoped");
        }
    }
}
