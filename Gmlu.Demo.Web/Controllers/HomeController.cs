using Gmlu.Demo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gmlu.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static List<Todo> Todos = new List<Todo>
        {
            new Todo {Id = 1, Description = "MVC lernen", Done = false},
            new Todo {Id = 2, Description = "MVC anwenden", Done = false},
            new Todo {Id = 3, Description = "Lösung programmieren", Done = false},
            new Todo {Id = 4, Description = "Lösung deployen", Done = false},
            new Todo {Id = 5, Description = "feiern", Done = false},
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            var viewModel = new TodoViewModel();
            viewModel.Todos = Todos;
            viewModel.CreateModel = new Todo();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateTodo(
            Todo createModel)
        {
            Todos
                .Add(
                    createModel);

            return RedirectToAction("Test");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
