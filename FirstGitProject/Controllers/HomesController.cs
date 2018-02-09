using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstGitProject.Models;
using FirstGitProject.ViewModels;

namespace FirstGitProject.Controllers
{
    public class HomesController : Controller
    {
        private ApplicationDbContext _context;

        public HomesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var homes = _context.Homes.Include(m => m.Genre).ToList();

            return View(homes);
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new HomeFormViewModel
            {
                Genres = genres
            };

            return View("HomeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var home = _context.Homes.SingleOrDefault(c => c.Id == id);

            if (home == null)
                return HttpNotFound();

            var viewModel = new HomeFormViewModel
            {
                Home = home,
                Genres = _context.Genres.ToList()
            };

            return View("HomeForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var home = _context.Homes.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (home == null)
                return HttpNotFound();

            return View(home);
        }
       

        // GET: Movies/Random
        public ActionResult Random()
        {
            var home = new Home() { Address = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomHomeViewModel
            {
                Home = home,
                Customers = customers
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Home home)
        {
            if (home.Id == 0)
            {
               // home.DateAdded = DateTime.Now;
                _context.Homes.Add(home);
            }
            else
            {
                var homeInDb = _context.Homes.Single(m => m.Id == home.Id);
                homeInDb.Address = home.Address;
                homeInDb.City = home.City;
                homeInDb.State = home.State;
                homeInDb.Zip = home.Zip;
                homeInDb.GenreId = home.GenreId;
               
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Homes");
        }
    }
}