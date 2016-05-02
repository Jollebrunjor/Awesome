using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Awesome.Models;
using Awesome.Models.DB;
using Awesome.Models.EntityManager;
using Awesome.Models.ViewModel;

namespace Awesome.Controllers
{

    public class MyPageController : Controller
    {
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        [HttpPost]
        public ActionResult PlaceBet(MyPageViewModel placedBet, string username)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "The password provided is incorrect.");
                return new RedirectResult(Url.Action("Index") + "#myBet");
            }

            UserBet userBet = new UserBet();

            foreach (var bet in placedBet.Bet.Matches)
            {
                Match match = new Match()
                {
                    HomeTeam = bet.HomeTeam,
                    AwayTeam = bet.AwayTeam,
                    HomeScore = bet.HomeScore,
                    AwayScore = bet.AwayScore
                };

                userBet.Matches.Add(match);
                userBet.Finalist1 = placedBet.Bet.Finalist1;
                userBet.Finalist2 = placedBet.Bet.Finalist2;
                userBet.Semifinalist1 = placedBet.Bet.Semifinalist1;
                userBet.Semifinalist2 = placedBet.Bet.Semifinalist2;
                userBet.Semifinalist3 = placedBet.Bet.Semifinalist3;
                userBet.Semifinalist4 = placedBet.Bet.Semifinalist4;
                userBet.QuarterFinalist1 = placedBet.Bet.QuarterFinalist1;
                userBet.QuarterFinalist2 = placedBet.Bet.QuarterFinalist2;
                userBet.QuarterFinalist3 = placedBet.Bet.QuarterFinalist3;
                userBet.QuarterFinalist4 = placedBet.Bet.QuarterFinalist4;
                userBet.QuarterFinalist5 = placedBet.Bet.QuarterFinalist5;
                userBet.QuarterFinalist6 = placedBet.Bet.QuarterFinalist6;
                userBet.QuarterFinalist7 = placedBet.Bet.QuarterFinalist7;
                userBet.QuarterFinalist8 = placedBet.Bet.QuarterFinalist8;
                userBet.TopScorer = placedBet.Bet.TopScorer;
                userBet.TotalGoals = placedBet.Bet.TotalGoals;

            }



            UserManager.AddBet(userBet, username);

            return new RedirectResult(Url.Action("Index") + "#myBet");
        }

        [Authorize]
        public ActionResult Index()
        {
            FootballApiClient client = new FootballApiClient();
            JsonGroupStageResult groupStageMatches = client.GetGroupStageMatches();
            JsonTeamResult teams = client.GetTeams();

            MyPageViewModel currentGamlePage = new MyPageViewModel(teams, groupStageMatches);
            
            return View(currentGamlePage);
            
        }


        [Authorize]
        public ActionResult MyResultsPage()
        {
            FootballApiClient client = new FootballApiClient();

            BetPageViewModel bet = new BetPageViewModel();

            return View(bet);
        }



    }
}