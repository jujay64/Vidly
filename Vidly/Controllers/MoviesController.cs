using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

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

        // GET: Movies
        public ActionResult Index()
        {
            return View(_context.Movies.Include(m => m.Genre).ToList());
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            viewModel.Movie.AddedToDatabaseDate = DateTime.Now;

            if (viewModel.Movie.Id == 0)//New
            {
                _context.Movies.Add(viewModel.Movie);
            }
            else//Edit
            {
                var movie = _context.Movies.Single(m => m.Id == viewModel.Movie.Id);

                movie.GenreId = viewModel.Movie.GenreId;
                movie.Name = viewModel.Movie.Name;
                movie.ReleasedDate = viewModel.Movie.ReleasedDate;
                movie.Stock = viewModel.Movie.Stock;

            }

            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m=>m.Genre).SingleOrDefault(m=>m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}