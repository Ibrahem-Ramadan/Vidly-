using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ModelView;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Random()
        {
            var viewModel = new RondomMovieViewModel
            { 
                Movie = _context.Movies.ToList().ElementAt(0),
                Customers = _context.Customers.ToList()
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(G => G.Genre).ToList();
            return View(movies);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            if (_context.Movies.ToList().Count < id || id <= 0)
                return HttpNotFound();

            var movie =  _context.Movies.Include(G => G.Genre).ToList().ElementAtOrDefault(id-1);
            return View(movie);
        }
        
        [Route("movies/release/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year , int month)
        {
            return Content(year+"/"+month);
        }

        public ActionResult NewMovie()
        {
            var MovieViewModel = new MovieFormViewModel
            {
                Genres = _context.Genres
            };
            return View("MovieForm",MovieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie Movie)
        {
            if (!ModelState.IsValid)
            {
                var movieFormVm = new MovieFormViewModel
                {
                    Movie = Movie,
                    Genres = _context.Genres.ToList()

                };
                return View("MovieForm",movieFormVm);
        
            }

            Movie.DateAdded = DateTime.Now.Date;

            if (Movie.id == 0)
            {
                _context.Movies.Add(Movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.id == Movie.id);
                movieInDb.name = Movie.name;
                movieInDb.ReleaseDate = Movie.ReleaseDate;
                movieInDb.GenreId = Movie.GenreId; 
                movieInDb.DateAdded = Movie.DateAdded;
                movieInDb.NumberInStock = Movie.NumberInStock;

            }
            _context.SaveChanges();
            return View("Index",_context.Movies.Include(G => G.Genre).ToList());
        }
        public ActionResult Edit(int id)
        {
            var movieInDB = _context.Movies.Single(m => m.id == id);
            var movieFormVm = new MovieFormViewModel
            {
               Movie = movieInDB,
               Genres = _context.Genres
            };
            return View("MovieForm",movieFormVm);
        }
        public ActionResult Delete(int id)
        {

            var MovieToBeDeleted = _context.Movies.Single(c => c.id == id);
            _context.Movies.Remove(MovieToBeDeleted);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
      
    }
}