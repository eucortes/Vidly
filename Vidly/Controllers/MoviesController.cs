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



    }
}