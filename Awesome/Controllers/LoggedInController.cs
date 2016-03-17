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
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;


namespace Awesome.Controllers
{

    public class LoggedInController : Controller
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
        public ActionResult PlaceBet(Awesome.Models.ViewModel.PlaceBetPageViewModel placedBet, string username)
            {

        UserBet userBet = new UserBet();
            
            foreach (var bet in placedBet.Bet.Matches)
            {
                Match match = new Match()
                {
                    HomeTeam = bet.homeTeamName,
                    AwayTeam = bet.awayTeamName,
                    HomeScore = bet.result.goalsHomeTeam??0,
                    AwayScore = bet.result.goalsAwayTeam??0


                };

                userBet.Matches.Add(match);
                userBet.Finalist1 = placedBet.Bet.Finalist1;
                userBet.Finalist2 = placedBet.Bet.Finalist2;
                userBet.Semifinalist1 = placedBet.Bet.Semifinalist1;
                userBet.Semifinalist2 = placedBet.Bet.Semifinalist2;
                userBet.TopScorer = placedBet.Bet.TopScorer;

            }
  
            UserManager.AddBet(userBet, username);

            return RedirectToAction("MyBetPage", "LoggedIn");
        }

        [Authorize]
        public ActionResult MyBetPage()
        {
            BetPageViewModel myBetPage = new BetPageViewModel();
            return View(myBetPage);
        }

        [Authorize]
        public ActionResult MyPage()
        {
            return View();
        }

        [Authorize]
        public ActionResult PlaceBetPage()
        {
         
            FootballApiClient client = new FootballApiClient();
            JsonGroupStageResult groupStageMatches = client.GetGroupStageMatches();
            JsonTeamResult teams = client.GetTeams();

            PlaceBetPageViewModel currentGamlePage = new PlaceBetPageViewModel(teams, groupStageMatches);

            if (!currentGamlePage.HasBetted)
            {
                return View(currentGamlePage);
            }
            else
            {
                return RedirectToAction("MyBetPage", "LoggedIn");
            }
         
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