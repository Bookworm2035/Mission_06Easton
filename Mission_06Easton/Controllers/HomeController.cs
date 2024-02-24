using Microsoft.AspNetCore.Mvc;
using Mission_06Easton.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
        //home page
        public IActionResult Index()
        {
            return View();
        }
        //joel info page
        public IActionResult Joel()
        {
            return View();
        }
        //subbmisions page
        [HttpGet]
        public IActionResult Form()
        {
           //var majors = _MovieContext.Categories.ToList();
           //store info in viewbag 
            ViewBag.Categories = _MovieContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Form", new Movie());
        }

        [HttpPost]
        public IActionResult Form(Movie response)
        {
            if (ModelState.IsValid) {
                //confirm that the submission meets requirements
                _MovieContext.Movies.Add(response);
                _MovieContext.SaveChanges();
                return View("Confirmation", response);

            }
            else
            {
                //if bad return error meessages
                ViewBag.Categories = _MovieContext.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }
            
        }

        //TABLE (IE database view) with crud functionality

        public IActionResult Table()
        {
            //display database
           var movies = _MovieContext.Movies.Include(m => m.Category)
                    //.Where(x => x.COLUM == value)
                        .OrderBy(x => x.MovieId).ToList();
            return View(movies);
        }


        //edit views

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //pull in the reccord you want to edit and pass it into the form
            var recordToEdit = _MovieContext.Movies
                .Single(x => x.MovieId == id);
                //FirstOrDefault(x => x.MovieId == id);
                //.Single(x => x.MovieId == id);

            ViewBag.Categories = _MovieContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updateresponse) {
            //update the datebase with the new edits
            _MovieContext.Update(updateresponse);
            _MovieContext.SaveChanges();
            //return to view
            return RedirectToAction("Table", "Home");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            //delete the record by ID num
            var recordToDelete = _MovieContext.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            //actually delete it
            _MovieContext.Movies.Remove(movie);
            _MovieContext.SaveChanges();

            return RedirectToAction("Table");
        }
    }
}
