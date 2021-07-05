using System;
using System.Collections.Generic;
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
        List<Movie> movies = new List<Movie>{
            new Movie{id = 1 , name = "Shrek!" , Type = "Comedy"},
            new Movie{id = 2 , name = "Wall-e" , Type = "Science Fiction"}
        };
        public ActionResult Random()
        {
            var movie = new Movie() { name = "Ztopia" };
            var customers = new List<Customer> { 
            
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            
            };

            var viewModel = new RondomMovieViewModel
            { 
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id = "+ id);
        }


        public ActionResult Index()
        {

            return View(movies);
        }
        
        [Route("movies/release/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year , int month)
        {
            return Content(year+"/"+month);
        }
      
    }
}