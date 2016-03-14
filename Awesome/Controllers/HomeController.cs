
using System.Web.Mvc;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Awesome.Models;
using Awesome.Models.ViewModel;

namespace Awesome.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Logout"] = TempData["Logout"];
            return View();
        }

        public ActionResult Standings()
        {
            HomeViewModel currentViewModel = new HomeViewModel();

            ViewBag.Message = "Tabellen.";

            return View(currentViewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Welcome()
        {
            return View();
        }
    }
}