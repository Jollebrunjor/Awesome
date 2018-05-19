using System;
using System.Collections.Generic;
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
            if (!this.IsValidUserBet(placedBet.Bet))
            {
                if (base.TempData["Fail"] == null)
                {
                    base.TempData.Add("Fail", "N\x00e5got blev tokigt, f\x00f6rs\x00f6k igen. T\x00e4nk p\x00e5 att ange olika lag i åttondelsfinal, kvartsfinal, semifinal och final.");
                }
                return new RedirectResult(base.Url.Action("Index") + "#myBet");
            }
            UserManager.AddBet(userBet, username);
            if (base.TempData["Thanks"] == null)
            {
                base.TempData.Add("Thanks", "Tack f\x00f6r spelet");
            }
            return new RedirectResult(base.Url.Action("Index"));
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

        public bool IsValidUserBet(Bet bet)
        {
            List<string> list = new List<string>();
            List<string> list1 = new List<string> {
                bet.QuarterFinalist1,
                bet.QuarterFinalist2,
                bet.QuarterFinalist3,
                bet.QuarterFinalist4,
                bet.QuarterFinalist5,
                bet.QuarterFinalist6,
                bet.QuarterFinalist7,
                bet.QuarterFinalist8
            };
            List<string> list2 = new List<string>()
            {
                bet.Qualified1,
                bet.Qualified2,
                bet.Qualified3,
                bet.Qualified4,
                bet.Qualified5,
                bet.Qualified6,
                bet.Qualified7,
                bet.Qualified8,
                bet.Qualified9,
                bet.Qualified1,
                bet.Qualified11,
                bet.Qualified12,
                bet.Qualified13,
                bet.Qualified14,
                bet.Qualified15,
                bet.Qualified16,
        };
            list.Add(bet.Semifinalist1);
            list.Add(bet.Semifinalist2);
            list.Add(bet.Semifinalist3);
            list.Add(bet.Semifinalist4);

            bool qflag = list2.GroupBy(n => n).Any(c => c.Count() > 1);
            bool sfinalFlag = list.GroupBy(n => n).Any(c => c.Count() > 1);

            return (!(list1.GroupBy(n => n).Any(c => c.Count() > 1) && !sfinalFlag && !qflag) && (bet.Finalist1 != bet.Finalist2));
        }
    }
}