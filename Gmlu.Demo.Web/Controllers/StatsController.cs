using Microsoft.AspNetCore.Mvc;
using System;
using Gmlu.Demo.Web.Models;
using Gmlu.Demo.Web.Services;

namespace Gmlu.Demo.Web.Controllers
{
    public class StatsController : Controller
    {
        public IActionResult Index()
        {
            var service = new StateServiceLocal();

            var viewModel = new StatsViewModel();
            viewModel.DateToFilter = DateTime.Now;
            viewModel.MeasurePoints = service
                .GetMeasurePoints(
                    DateTime.Now);

            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Filter(
            StatsViewModel viewModel)
        {
            var service = new StateServiceLocal();

            viewModel.MeasurePoints = service
                .GetMeasurePoints(
                    viewModel.DateToFilter);

            return View("index", viewModel);
        }

    }
}
