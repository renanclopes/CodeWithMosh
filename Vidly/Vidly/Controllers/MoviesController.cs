using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> _movies = new List<Movie>
        {
            new Movie {Id = 1, Name = "Movie 1"},
            new Movie {Id = 2, Name = "Movie 2"}
        };

        // GET: Movies
        public ActionResult Index()
        {
            return View(_movies);
        }

        public ActionResult MovieDetails(int Id)
        {
            var movie = _movies.Where(x => x.Id == Id).FirstOrDefault();

            if (movie == null)
                return HttpNotFound();            

            return View(movie);
        }

    }
}