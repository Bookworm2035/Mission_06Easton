using Microsoft.AspNetCore.Mvc;
using Mission_06Easton.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Mission_06Easton.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _MovieContext;
        //private readonly ILogger<HomeController> _logger;

        // Consolidate constructors into one
        public HomeController(MovieContext MovieContext) //contructor temp
        {
            _MovieContext = MovieContext;
            //_logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Joel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Movie response)
        {
            _MovieContext.Movies.Add(response);
            _MovieContext.SaveChanges();
            return View("Confirmation", response);
        }

    }
}
