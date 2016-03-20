
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Awesome.Models;
using Awesome.Models.EntityManager;
using Awesome.Models.ViewModel;

namespace Awesome.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            object message = string.Empty;
   
            HomeViewModel currentViewModel = new HomeViewModel();
            ViewData["Logout"] = TempData["Logout"];

            if (TempData.TryGetValue("signuperror", out message))
            {
                currentViewModel.SignupErrorMessage = message;
            }
            if (TempData.TryGetValue("loginerror", out message))
            {
                currentViewModel.LoginErrorMessage = message;
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
