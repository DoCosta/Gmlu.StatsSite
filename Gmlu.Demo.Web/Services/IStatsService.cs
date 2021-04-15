using System;
using System.Collections.Generic;
using Gmlu.Demo.EntityFramework.Models;

namespace Gmlu.Demo.Web.Services
{
    public interface IStatsService
    {
        IEnumerable<MeasurePoint> GetMeasurePoints(
            Guid RaspberryId,
            DateTime dateToLoad);
    }
}
