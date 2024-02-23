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
           //var majors = _MovieContext.Categories.ToList();

            ViewBag.Categories = _MovieContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Form", new Movie());
        }

        [HttpPost]
        public IActionResult Form(Movie response)
        {
            if (ModelState.IsValid) {
                _MovieContext.Movies.Add(response);
                _MovieContext.SaveChanges();
                return View("Confirmation", response);

            }
            else
            {
                ViewBag.Categories = _MovieContext.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }
            
        }

        //TABLE (IE database view) with crud functionality

        public IActionResult Table()
        {
           var movies = _MovieContext.Movies
                    //.Where(x => x.COLUM == value)
                    .OrderBy(x => x.Title).ToList();
            return View(movies);
        }


        //edit views

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _MovieContext.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _MovieContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Table", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updateresponse) {
            _MovieContext.Update(updateresponse);
            _MovieContext.SaveChanges();
            return RedirectToAction("Table");
        }




        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _MovieContext.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _MovieContext.Movies.Remove(movie);
            _MovieContext.SaveChanges();

            return RedirectToAction("Table");
        }
    }
}
