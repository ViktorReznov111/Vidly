using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {


        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //
        // GET: /Movies/Random



        public ActionResult Random()
        {
            var movie = new Movie() { Name = "shrek!" };

            var customers = new List<Customer>
		   {
			   new Customer {Name="Customer 1"},
			   new Customer {Name="Customer 2"}

		   };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers

            };


            return View(viewModel);

        }





        public ActionResult Movies()
        {
            var movies = new List<Movie>
		   {
			   new Movie {Name="shrek"},
			   new Movie {Name="lotr"}

		   };


            return View(movies);

        }



        public ActionResult Index()
        {
            var movies = _context.Movies.Include(a => a.Genre).ToList();


            return View(movies);
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(a => a.Genre).SingleOrDefault(m => m.id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);

        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}


        //[Route("movies/released/{year}/{month:regex(\\{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year+ "/" + month);
        //}


        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new NewMovieViewModel
            {
                Movie = new Movie {ReleaseDate=DateTime.Today },
                Genres = genres

            };

            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NewMovieViewModel movieViewModel, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()


                };
                return View("MovieForm",viewModel);
            }

            if (movieViewModel.Movie.id==0) //new
            {
               movieViewModel.Movie.DateAdded=DateTime.Now;
                _context.Movies.Add(movieViewModel.Movie);   
            }

            else
            {
                var SelectedMovie=new Movie();

                SelectedMovie = _context.Movies.Single(m => m.id == movieViewModel.Movie.id);

                SelectedMovie.Name = movieViewModel.Movie.Name;
                SelectedMovie.GenreId = movieViewModel.Movie.GenreId;
                SelectedMovie.DateAdded = DateTime.Now;
                SelectedMovie.NumberInStock = movieViewModel.Movie.NumberInStock;
                SelectedMovie.ReleaseDate = movieViewModel.Movie.ReleaseDate;

            }

            _context.SaveChanges();
            

          
            return RedirectToAction("Index","Movies");
        }

        public ActionResult Edit(int id)
        {
            var selectedMovie = _context.Movies.Single(m=>m.id==id);

            if (selectedMovie == null) return HttpNotFound();

            var viewModel = new NewMovieViewModel
            {
                Movie= selectedMovie,
                Genres=_context.Genres.ToList()

            };

            return View("MovieForm",viewModel);
        }
    }
}