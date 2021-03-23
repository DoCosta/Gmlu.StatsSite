using Gmlu.Demo.EntityFramework.DataContext;
using Gmlu.Demo.Web.Interfaces.Raspy.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            foreach (var data in _context.Raspberrys)
            {
                var ipaddress = data.IPadress;

                // Raspberry.IdAdress => $"{http://{idaddress}/}
                string url = "http://" + ipaddress;

                // HttpClient
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // response => json
                string json = await response.Content.ReadAsStringAsync();
                
                // json => Deserialize to Object (Newtonsoft.Json) => JsonConverter.DeserializeObject<OBJECT>(json)
                RaspyData raspberry = JsonConvert.DeserializeObject<RaspyData>(json);

                // save DIFF to Database
                // _context.MeasurePoints = _context.MeasurePoints.Add();
                //_context.SaveChanges();
            }

            _logger.LogInformation("RaspberrySyncJob stoped");
        }
    }
}
