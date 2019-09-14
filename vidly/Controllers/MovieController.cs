using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModel;

namespace vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _contex;

        public MovieController()
        {
            _contex = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contex.Dispose();
        }

        // GET: Movies
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!!" };

        //    var Customer = new List<Customer>
        //    {
        //        new Customer{Name = "Customer_1"},
        //        new Customer{Name = "Customer_2"}
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = Customer
        //    };
        //    return View(viewModel);
        //    //return HttpNotFound();
        //    //return Content("Hello Worls");
        //}

        public ViewResult Index()
        {
            var movies = _contex.Movies.ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = _contex.Movies.FirstOrDefault(c => c.Id == id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movies);
            }
        }

        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie{Id = 1, Name = "Shreck" },
        //        new Movie{Id = 2, Name = "Wall li"}
        //    };
        //}

        // Route test

        //[Route("movies/released/{year:regex(\\d{4}):range(2000, 2019)}/{month:regex(\\d{2}):range(1, 12)}")]
        //public ActionResult ByReleaseData(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}