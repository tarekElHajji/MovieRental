using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.Models;
using MovieRental.ViewModels;
using System.Data.Entity;


namespace MovieRental.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie{Id=1, Name = "Cast away"},
        //        new Movie{Id=2, Name = "The shawshenk redemption"},
        //        new Movie{Id=3, Name = "Rocky"}
        //    };
        //}

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();

            var movieFormViewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View(movieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            var genres = _context.Genres.ToList();

            var movieFormViewModel = new MovieFormViewModel()
            {
                Genres = genres,
                Movie = movie
            };

            return View(movieFormViewModel);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var movieFormViewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View(movieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var genres = _context.Genres.ToList();

                var movieFormViewModel = new MovieFormViewModel()
                {
                    Genres = genres,
                    Movie = movie
                };

                return View(movieFormViewModel);
            }
            var updatedMovie = _context.Movies.Single(c => c.Id == movie.Id);

            updatedMovie.Name = movie.Name;
            updatedMovie.ReleaseDate = movie.ReleaseDate;
            updatedMovie.DateAdded = movie.DateAdded;
            updatedMovie.Stock = movie.Stock;
            updatedMovie.GenreId = movie.GenreId;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}