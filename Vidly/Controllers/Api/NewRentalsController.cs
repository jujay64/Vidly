using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AutoMapper.Internal;
using Microsoft.Ajax.Utilities;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context { get; set; }

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {            
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
                              
            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();
           
            var rentalDate = DateTime.Now;

            foreach (var movie in movies)
            {
                if (movie.StockAvailable == 0)
                    return BadRequest("Movie is not available.");

                var rental = new Rental()
                {
                    Movie = movie,
                    Customer = customer,
                    RentedDate = rentalDate,

                };

                _context.Rentals.Add(rental);

                movie.StockAvailable--;
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
