using System.Web.Mvc;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Awesome.Models;
using Awesome.Models.ViewModel;

namespace Awesome.Controllers
{
    public class PlayerBetController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            FootballApiClient client = new FootballApiClient();
            JsonGroupStageResult groupStageMatches = client.GetGroupStageMatches();
            JsonTeamResult teams = client.GetTeams();

            MyPageViewModel currentGamlePage = new MyPageViewModel(teams, groupStageMatches, null);

            return View(currentGamlePage);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Index(string userName)
        {
            FootballApiClient client = new FootballApiClient();
            JsonGroupStageResult groupStageMatches = client.GetGroupStageMatches();
            JsonTeamResult teams = client.GetTeams();

            MyPageViewModel currentGamlePage = new MyPageViewModel(teams, groupStageMatches, userName);

            return View(currentGamlePage);
        }
    }
}