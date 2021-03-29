using System;
using System.Collections.Generic;
using System.Linq;
using Gmlu.Demo.EntityFramework.DataContext;
using Gmlu.Demo.EntityFramework.Models;

namespace Gmlu.Demo.Web.Services
{
    public class StatsServiceDb
        : IStatsService
    {
        private readonly StatsContext _context;

        public StatsServiceDb(
            StatsContext context)
        {
            _context = context;
        }

        public IEnumerable<MeasurePoint> GetMeasurePoints(
            Guid rspsberryId,
            DateTime dateToLoad)
        {
            var startTime = new DateTime(dateToLoad.Year, dateToLoad.Month, dateToLoad.Day, 0, 0, 0);
            var endTime = new DateTime(dateToLoad.Year, dateToLoad.Month, dateToLoad.Day, 23, 59, 59);

            var points = _context
                .MeasurePoints
                .Where(
                    x => x.Date > startTime
                      && x.Date < endTime
                      && x.RaspberryId == rspsberryId)
                .OrderBy(
                    x => x.Date);

            return points;
        }
    }
}
