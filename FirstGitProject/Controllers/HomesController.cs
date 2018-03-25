using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FirstGitProject.Models;
using FirstGitProject.ViewModels;
using Microsoft.Owin.Security.Provider;

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
            if (User.IsInRole(RoleName.CanManageHomes))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageHomes)]
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

            var viewModel = new HomeFormViewModel(home)
            {
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
        [ValidateAntiForgeryToken]
        public ActionResult Save(Home home, HttpPostedFileBase photo)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new HomeFormViewModel(home)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("HomeForm", viewModel);
            }

            if (photo != null)
            {
                if (!isValidContentType(photo.ContentType))
                {
                    var viewModel = new HomeFormViewModel(home)
                    {
                        Genres = _context.Genres.ToList()
                    };

                    ViewBag.Error = "Only JPG, JPEG, PNG & GIF files are allowed.";

                    return View("HomeForm", viewModel);
                }
                else if (!isValidContentLength(photo.ContentLength))
                {
                    var viewModel = new HomeFormViewModel(home)
                    {
                        Genres = _context.Genres.ToList()
                    };

                    ViewBag.Error = "Your file is too large.";

                    return View("HomeForm", viewModel);
                }
                else
                {
                    if (photo.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(photo.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                        photo.SaveAs(path);
                    }
                }

            }


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

        private bool isValidContentType(string contentType)
        {
            return contentType.Equals("image/png") || contentType.Equals("image/gif") || contentType.Equals("image/jpg") ||
                   contentType.Equals("image/jpeg");
        }

        private bool isValidContentLength(int contentLength)
        {
            return ((contentLength / 1024) / 1024) < 1; // 1MB
        }
    }
}