using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.Models.DB;

namespace Awesome.Models
{
    public class Bet
    {
        public Bet()
        {
            
        }
        public Bet(JsonGroupStageResult groupStageResult)
        {
            Matches = GetMatches(groupStageResult);
        }

        public int UserBetId { get; set; }
        public List<Fixture> Matches { get; set; }
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

        public List<Fixture> GetMatches(JsonGroupStageResult groupStageResult)
        {
            List<Fixture> groupStageMatches = new List<Fixture>();

            foreach (var match in groupStageResult.fixtures)
            {

                groupStageMatches.Add(match);

            }
            return groupStageMatches;
        }



    }
}
