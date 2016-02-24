using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Awesome.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Logout"] = TempData["Logout"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult MyPage()
        {
           return View();
        }

        [Authorize]
        public ActionResult Welcome()
        {
            return View();
        }
    }
}