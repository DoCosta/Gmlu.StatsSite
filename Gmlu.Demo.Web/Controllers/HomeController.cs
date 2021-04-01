using Microsoft.AspNetCore.Mvc;

namespace Gmlu.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("index", "Stats");
        }

    }
}
