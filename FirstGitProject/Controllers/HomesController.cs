using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstGitProject.Models;

namespace FirstGitProject.Controllers
{
    public class HomesController : Controller
    {
        // GET: Homes/Random
        public ActionResult Random()
        {
            var home = new Home { Address = "2124 N Menard"};

            return View(home);
        }
    }
}