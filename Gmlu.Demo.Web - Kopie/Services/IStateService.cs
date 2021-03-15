using System;
using System.Collections.Generic;
using Gmlu.Demo.Web.Models;

namespace Gmlu.Demo.Web.Services
{
    public interface IStateService
    {
        IEnumerable<MeasurePoint> GetMeasurePoints(
            DateTime? dateToLoad);
    }
}
