using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Awesome.Models;
using Awesome.Models.DB;
using Awesome.Models.EntityManager;
using Awesome.Models.ViewModel;
using Result = Awesome.Models.DB.Result;

namespace Awesome.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            FootballApiClient client = new FootballApiClient();
            JsonGroupStageResult groupStageMatches = client.GetGroupStageMatches();
            JsonTeamResult teams = client.GetTeams();
            AdminViewModel viewModel = new AdminViewModel(teams, groupStageMatches);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ReportResult(AdminViewModel viewModel)
        {
            Result result = new Result();

            foreach (var r in viewModel.ReportedResult.Matches)
                {
               
                MatchResult match = new MatchResult()
                {
                    HomeTeam = r.HomeTeam,
                    AwayTeam = r.AwayTeam,
                    HomeScore = r.HomeScore,
                    AwayScore = r.AwayScore,
                    MatchResultId = r.MatchId,  
                    Status = r.Status
                                       
                };

                result.MatchResults.Add(match);
                result.Finalist1 = viewModel.ReportedResult.Finalist1;
                result.Finalist2 = viewModel.ReportedResult.Finalist2;
                result.Semifinalist1 = viewModel.ReportedResult.Semifinalist1;
                result.Semifinalist2 = viewModel.ReportedResult.Semifinalist2;
                result.Semifinalist3 = viewModel.ReportedResult.Semifinalist3;
                result.Semifinalist4 = viewModel.ReportedResult.Semifinalist4;
                result.QuarterFinalist1 = viewModel.ReportedResult.QuarterFinalist1;
                result.QuarterFinalist2 = viewModel.ReportedResult.QuarterFinalist2;
                result.QuarterFinalist3 = viewModel.ReportedResult.QuarterFinalist3;
                result.QuarterFinalist4 = viewModel.ReportedResult.QuarterFinalist4;
                result.QuarterFinalist5 = viewModel.ReportedResult.QuarterFinalist5;
                result.QuarterFinalist6 = viewModel.ReportedResult.QuarterFinalist6;
                result.QuarterFinalist7 = viewModel.ReportedResult.QuarterFinalist7;
                result.QuarterFinalist8 = viewModel.ReportedResult.QuarterFinalist8;
                result.TopScorer = viewModel.ReportedResult.TopScorer;
                result.TotalGoals = viewModel.ReportedResult.TotalGoals;

            }

            
            UserManager.AddResult(result, true);

            ViewBag.Message = "Resultatet uppdaterat";
            viewModel.HasReported = true;
        
            return View("Index", viewModel);
        }
    }
}