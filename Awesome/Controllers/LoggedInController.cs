using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Awesome.Models;
using Awesome.Models.ViewModel;

namespace Awesome.Controllers
{
    public class LoggedInController : Controller
    {

        [Authorize]
        public ActionResult MyPage()
        {
            return View();
        }

        [Authorize]
        public ActionResult GamblePage()
        {
            FootballApiClient client = new FootballApiClient();
            JsonGroupStageResult groupStageMatches = client.GetGroupStageMatches();
            JsonTeamResult teams = client.GetTeams();

            GamblePageViewModel currentGamlePage = new GamblePageViewModel(teams, groupStageMatches);
            return View(currentGamlePage);
        }

        [Authorize]
        public ActionResult MyResultsPage()
        {
            return View();
        }

    }
}