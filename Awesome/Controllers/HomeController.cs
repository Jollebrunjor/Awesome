using System.Web.Mvc;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.Models;
using Awesome.Models.ViewModel;

namespace Awesome.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            object message = string.Empty;

            FootballApiClient client = new FootballApiClient();
            JsonGroupStageResult groupStageMatches = client.GetGroupStageMatches();

            HomeViewModel currentViewModel = new HomeViewModel(groupStageMatches);
            ViewData["Logout"] = TempData["Logout"];

            if (TempData.TryGetValue("signuperror", out message))
            {
                currentViewModel.SignupErrorMessage = message.ToString();
            }
            if (TempData.TryGetValue("loginerror", out message))
            {
                currentViewModel.LoginErrorMessage = message.ToString();
            }

            return View(currentViewModel);
        }

        public ActionResult Standings()
        {
            ViewBag.Message = "Tabellen.";

            return View();
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
