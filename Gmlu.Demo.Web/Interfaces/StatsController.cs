using Microsoft.AspNetCore.Mvc;
using System;
using Gmlu.Demo.Web.Models;
using Gmlu.Demo.Web.Services;
using System.Collections.Generic;
using Gmlu.Demo.EntityFramework.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Gmlu.Demo.EntityFramework.Models;

namespace Gmlu.Demo.Web.Controllers
{
    public class StatsController : Controller
    {
        private readonly IStatsService _statsService;
        private readonly StatsContext _context;

        public StatsController(
            IStatsService statsService,
            StatsContext context)
        {
            _statsService = statsService;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new StatsViewModel();

            viewModel.Raspberrys = GetRaspberryStatsViewModel(
                DateTime.Now);

            viewModel.DateToFilter = DateTime.Now;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Filter(
            StatsViewModel viewModel)
        {
            viewModel.Raspberrys = GetRaspberryStatsViewModel(
                viewModel.DateToFilter);

            return View("index", viewModel);
        }

        public List<RaspberryStatsViewModel> GetRaspberryStatsViewModel(
            DateTime filterDate)
        {
            var raspberrys = _context
               .Raspberrys
               .AsNoTracking()
               .ToList();

            var list = raspberrys
                .Select(
                    raspberry => new RaspberryStatsViewModel
                    {
                        MeasurePoints = _statsService
                                    .GetMeasurePoints(
                                        raspberry.RaspberryId,
                                        filterDate)
                    })
                .ToList();

            list
                .Add(
                    new RaspberryStatsViewModel
                    {
                        MeasurePoints = list
                        .First()
                        .MeasurePoints
                        .Select(x => new MeasurePoint { Date = x.Date, Temp = x.Temp + 2, Humidity = x.Humidity + 2 })
                    });

            return list;
        }

    }
}
