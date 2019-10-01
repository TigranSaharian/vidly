using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using vidly.Models;

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

        public ViewResult Index()
        {
            var movies = _contex.Movies.Include(g => g.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = _contex.Movies.Include(g => g.Genre).FirstOrDefault(c => c.Id == id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movies);
            }
        }

        // Route test

        //[Route("movies/released/{year:regex(\\d{4}):range(2000, 2019)}/{month:regex(\\d{2}):range(1, 12)}")]
        //public ActionResult ByReleaseData(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}