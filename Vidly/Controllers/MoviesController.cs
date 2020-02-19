using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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
            List<Movie> movies=new List<Movie>
            {
                new Movie{Name = "Shrek!"},
                new Movie{Name = "Kung fu panda"},
            };
            var viewmodel =new MoviesIndexViewModel
            {
                Movies = movies
            };

            return View(viewmodel);
        }

    }
}