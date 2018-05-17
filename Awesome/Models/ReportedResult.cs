using System.Collections.Generic;
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

        public string Qualified1 { get; set; }
        public string Qualified2 { get; set; }
        public string Qualified3 { get; set; }
        public string Qualified4 { get; set; }
        public string Qualified5 { get; set; }
        public string Qualified6 { get; set; }
        public string Qualified7 { get; set; }
        public string Qualified8 { get; set; }
        public string Qualified9 { get; set; }
        public string Qualified10 { get; set; }
        public string Qualified11 { get; set; }
        public string Qualified12 { get; set; }
        public string Qualified13 { get; set; }
        public string Qualified14 { get; set; }
        public string Qualified15 { get; set; }
        public string Qualified16 { get; set; }
        public string TopScorer { get; set; }
        public int TotalGoals { get; set; }

    }
}