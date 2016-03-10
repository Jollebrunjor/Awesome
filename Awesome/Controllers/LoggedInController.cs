using System;
using System.Collections.Generic;
using System.Linq;
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
        
        [HttpPost]
        public ActionResult PlaceBet(int homeTeam_1, int awayTeam_1, int homeTeam_2, int awayTeam_2, int homeTeam_3, int awayTeam_3, int homeTeam_4, int awayTeam_4, int homeTeam_5, int awayTeam_5, int homeTeam_6, int awayTeam_6, int homeTeam_7, int awayTeam_7, int homeTeam_8, int awayTeam_8, int homeTeam_9, int awayTeam_9, int homeTeam_10, int awayTeam_10, int homeTeam_11, int awayTeam_11, int homeTeam_12, int awayTeam_12, int homeTeam_13, int awayTeam_13, int homeTeam_14, int awayTeam_14, int homeTeam_15, int awayTeam_15, int homeTeam_16, int awayTeam_16, int homeTeam_17, int awayTeam_17, int homeTeam_18, int awayTeam_18, int homeTeam_19, int awayTeam_19, int homeTeam_20, int awayTeam_20, int homeTeam_21, int awayTeam_21,
            int homeTeam_22, int awayTeam_22, int homeTeam_23, int awayTeam_23, int homeTeam_24, int awayTeam_24, int homeTeam_25, int awayTeam_25, int homeTeam_26, int awayTeam_26, int homeTeam_27, int awayTeam_27, int homeTeam_28, int awayTeam_28, int homeTeam_29, int awayTeam_29, int homeTeam_30, int awayTeam_30, int homeTeam_31, int awayTeam_31, int homeTeam_32, int awayTeam_32, int homeTeam_33, int awayTeam_33, int homeTeam_34, int awayTeam_34, int homeTeam_35, int awayTeam_35, int homeTeam_36, int awayTeam_36,
            string user)
        {
            
            
            Match match1 = new Match();
            match1.HomeScore = homeTeam_1;
            match1.AwayScore = awayTeam_1;
            match1.MatchNumber = 1;

            Match match2 = new Match();
            match2.HomeScore = homeTeam_2;
            match2.AwayScore = awayTeam_2;
            match2.MatchNumber = 2;

            Match match3 = new Match();
            match3.HomeScore = homeTeam_3;
            match3.AwayScore = awayTeam_3;
            match3.MatchNumber = 3;

            Match match4 = new Match();
            match4.HomeScore = homeTeam_4;
            match4.AwayScore = awayTeam_4;
            match4.MatchNumber   = 4;

            Match match5 = new Match();
            match5.HomeScore = homeTeam_5;
            match5.AwayScore = awayTeam_5;
            match5.MatchNumber   = 5;

            Match match6 = new Match();
            match6.HomeScore = homeTeam_6;
            match6.AwayScore = awayTeam_6;
            match6.MatchNumber   = 6;

            Match match7 = new Match();
            match7.HomeScore = homeTeam_7;
            match7.AwayScore = awayTeam_7;
            match7.MatchNumber   = 7;

            Match match8 = new Match();
            match8.HomeScore = homeTeam_8;
            match8.AwayScore = awayTeam_8;
            match8.MatchNumber = 8;

            Match match9 = new Match();
            match9.HomeScore = homeTeam_9;
            match9.AwayScore = awayTeam_9;
            match9.MatchNumber = 9;

            Match match10 = new Match();
            match10.HomeScore = homeTeam_10;
            match10.AwayScore = awayTeam_10;
            match10.MatchNumber = 10;

            Match match11 = new Match();
            match11.HomeScore = homeTeam_11;
            match11.AwayScore = awayTeam_11;
            match11.MatchNumber = 11;

            Match match12 = new Match();
            match12.HomeScore = homeTeam_12;
            match12.AwayScore = awayTeam_12;
            match12.MatchNumber = 12;

            Match match13 = new Match();
            match13.HomeScore = homeTeam_13;
            match13.AwayScore = awayTeam_13;
            match1.MatchNumber = 13;

            Match match14 = new Match();
            match14.HomeScore = homeTeam_14;
            match14.AwayScore = awayTeam_14;
            match14.MatchNumber = 14;

            Match match15 = new Match();
            match15.HomeScore = homeTeam_15;
            match15.AwayScore = awayTeam_15;
            match15.MatchNumber = 15;

            Match match16 = new Match();
            match16.HomeScore = homeTeam_16;
            match16.AwayScore = awayTeam_16;
            match16.MatchNumber = 16;

            UserBet placedBet = new UserBet();
            placedBet.Matches.Add(match1);
            placedBet.Matches.Add(match2);
            placedBet.Matches.Add(match3);
            placedBet.Matches.Add(match4);
            placedBet.Matches.Add(match5);
            placedBet.Matches.Add(match6);
            placedBet.Matches.Add(match7);
            placedBet.Matches.Add(match8);
            placedBet.Matches.Add(match9);
            placedBet.Matches.Add(match10);
            placedBet.Matches.Add(match11);
            placedBet.Matches.Add(match12);
            placedBet.Matches.Add(match13);
            placedBet.Matches.Add(match14);
            placedBet.Matches.Add(match15);
            placedBet.Matches.Add(match16);
            placedBet.Finalist1 = "final1";
            placedBet.Finalist2 = "final2";
            placedBet.Semifinalist1 = "semi1";
            placedBet.Semifinalist2 = "semi2";
            placedBet.TopScorer = "Zlatan";

            

            UserManager.AddBet(placedBet, user);

            return RedirectToAction("MyBetPage", "LoggedIn");
        }

        [Authorize]
        public ActionResult MyBetPage()
        {
            MyBetPageViewModel myBetPage = new MyBetPageViewModel();
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
            return View(currentGamlePage);
        }

        [Authorize]
        public ActionResult MyResultsPage()
        {
            return View();
        }



    }
}