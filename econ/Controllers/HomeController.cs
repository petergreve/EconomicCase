using econ.Data;
using econ.Models;
using econ.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace econ.Controllers
{
    public class HomeController : Controller
    {
        private ITimeRegistrationRepository _repo;

        public HomeController(ITimeRegistrationRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [Authorize]
        public ActionResult TimeRegistration()
        {
            return View();
        }
    }
}
