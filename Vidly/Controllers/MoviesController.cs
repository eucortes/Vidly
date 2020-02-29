using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context=new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
          //  ViewData["movie"]=movie; //no muy útiles porque pierdes la pista de lo que se crea
           // ViewBag.RandomMovie=movie;
            var movie =new Movie() {Name="shrek!"};
            var customers=new List<Customer>
            {
                new Customer{Name = "customer1"},
                new Customer{ Name = "customer2" }
            };

            var viewModel=new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);//es mas eficiente
        }
        [Route ("movies/released/{year}/{month:regex(\\d{2}):range(1,2)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(("year/month"));
        }
        public ActionResult Index()
        {

            var viewmodel = new MoviesIndexViewModel
            {
                Movies = _context.Movies.Include(c => c.Genre).ToList()
            };

            return View(viewmodel);
        }
        public ActionResult Details(int id )
        {
            Movie movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }else
            {
                return View(movie);

            }

        }
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),

            };
            return View("MovieForm", viewModel);


        }

        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel=new MovieFormViewModel(movie)
                {
                    Genres=_context.Genres.ToList (),

                };
                return View("MovieForm",viewModel);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel=new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm",viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {

                var MovieInDB=_context.Movies.Single(m=>m.Id==movie.Id);
                MovieInDB.Name=movie.Name;
                MovieInDB.GenreId = movie.GenreId;
                MovieInDB.DateAdded = movie.DateAdded;
                MovieInDB.ReleaseDate = movie.ReleaseDate;
                MovieInDB.InStock = movie.InStock;
                //MovieInDB.Name = movie.Name;

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

    }


}