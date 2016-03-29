using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.Models.DB;
using Awesome.Models.EntityManager;
using Result = Awesome.Models.DB.Result;

namespace Awesome.Models
{
    public class ReportedResult
    {
        public ReportedResult()
        {

        }
        public ReportedResult(JsonGroupStageResult groupStageMatches)
        {
            Matches = TournamentUtility.CreateMatchList(groupStageMatches);
            Result = UserManager.GetResult();
        }

        public int UserBetId { get; set; }
        public List<Match> Matches { get; set; }
        public Result Result { get; set; }
        public string Finalist1 { get; set; }
        public string Finalist2 { get; set; }
        public string Semifinalist1 { get; set; }
        public string Semifinalist2 { get; set; }
        public string Semifinalist3 { get; set; }
        public string Semifinalist4 { get; set; }
        public string QuarterFinalist1 { get; set; }
        public string QuarterFinalist2 { get; set; }
        public string QuarterFinalist3 { get; set; }
        public string QuarterFinalist4 { get; set; }
        public string QuarterFinalist5 { get; set; }
        public string QuarterFinalist6 { get; set; }
        public string QuarterFinalist7 { get; set; }
        public string QuarterFinalist8 { get; set; }
        public string TopScorer { get; set; }
        public int TotalGoals { get; set; }

    }
}