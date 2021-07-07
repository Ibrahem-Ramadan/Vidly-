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

        public ActionResult Edit(int id)
        {
            return Content("id = "+ id);
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
      
    }
}