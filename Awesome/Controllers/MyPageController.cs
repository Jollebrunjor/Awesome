using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Mvc;
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
                var errors = ModelState.Values.SelectMany(v => v.Errors);
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
                userBet.Qualified1 = placedBet.Bet.Qualified1;
                userBet.Qualified2 = placedBet.Bet.Qualified2;
                userBet.Qualified3 = placedBet.Bet.Qualified3;
                userBet.Qualified4 = placedBet.Bet.Qualified4;
                userBet.Qualified5 = placedBet.Bet.Qualified5;
                userBet.Qualified6 = placedBet.Bet.Qualified6;
                userBet.Qualified7 = placedBet.Bet.Qualified7;
                userBet.Qualified8 = placedBet.Bet.Qualified8;
                userBet.Qualified9 = placedBet.Bet.Qualified9;
                userBet.Qualified10 = placedBet.Bet.Qualified10;
                userBet.Qualified11 = placedBet.Bet.Qualified11;
                userBet.Qualified12 = placedBet.Bet.Qualified12;
                userBet.Qualified13 = placedBet.Bet.Qualified13;
                userBet.Qualified14 = placedBet.Bet.Qualified14;
                userBet.Qualified15 = placedBet.Bet.Qualified15;
                userBet.Qualified16 = placedBet.Bet.Qualified16;
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


        //[Authorize]
        //public ActionResult MyResultsPage()
        //{
        //    FootballApiClient client = new FootballApiClient();

        //    BetPageViewModel bet = new BetPageViewModel();

        //    return View(bet);
        //}



    }
}