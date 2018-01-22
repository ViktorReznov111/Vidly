using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using AutoMapper;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();


        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //if (newRental.MovieIds.Count == 0)
            //    return BadRequest("No movie ids given");

            var customer = _context.Customers.SingleOrDefault(
                c => c.id == newRental.CustomerId);


            //if (customer == null)
            //    return BadRequest("Customerid invalid");

           

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.id)).ToList();


            //if (movies.Count != newRental.MovieIds.Count)
            //    return BadRequest("one or more movieid invalid");


            foreach (var movie in movies)
            {
                if (movie.NumberAvaliable == 0)
                    return BadRequest("movie is not avaliable");

                movie.NumberAvaliable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);


            }
            _context.SaveChanges();
            return Ok();


        }


    }
}
