using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View(_context.Movies.ToList());
        }

        public ActionResult MovieDetails(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == Id);

            if (movie == null)
                return HttpNotFound();            

            return View(movie);
        }

    }
}