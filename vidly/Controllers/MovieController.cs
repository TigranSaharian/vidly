using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModel;

namespace vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(g => g.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(g => g.Genre).FirstOrDefault(c => c.Id == id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movies);
            }
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var ViewModel = new NewMovieViewModel
            {
                Genres = genres
            };
            return View("MovieForm", ViewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                _ = new NewMovieViewModel()
                {
                    Genres = _context.Genres.ToList()
                };
            }
            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieIdDb = _context.Movies.SingleOrDefault(x => x.Id == movie.Id);
                movieIdDb.Name = movie.Name;
                movieIdDb.NumberInStock = movie.NumberInStock;
                movieIdDb.ReleaseDate = movie.ReleaseDate;
                movieIdDb.DateAdded = movie.DateAdded;
                movieIdDb.Genre = movie.Genre;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
    }
}