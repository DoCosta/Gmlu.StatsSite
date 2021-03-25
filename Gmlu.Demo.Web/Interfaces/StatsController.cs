using Microsoft.AspNetCore.Mvc;
using System;
using Gmlu.Demo.Web.Models;
using Gmlu.Demo.Web.Services;

namespace Gmlu.Demo.Web.Controllers
{
    public class StatsController : Controller
    {
        private readonly IStatsService _statsService;

        public StatsController(
            IStatsService statsService)
        {
            _statsService = statsService;
        }

        public IActionResult Index()
        {
            var viewModel = new StatsViewModel();
            viewModel.DateToFilter = DateTime.Now;
            viewModel.MeasurePoints = _statsService
                .GetMeasurePoints(
                    DateTime.Now);

            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Filter(
            StatsViewModel viewModel)
        {
            )
            viewModel.MeasurePoints = _statsService
                .GetMeasurePoints(
                    viewModel.DateToFilter);
            
            return View("index", viewModel);
        }

    }
}
