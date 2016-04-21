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
        public Bet(JsonGroupStageResult groupStageMatches)
        {
            Matches = TournamentUtility.CreateMatchList(groupStageMatches);
        }

        public int UserBetId { get; set; }

        public List<Match> Matches { get; set; }
        [Required(ErrorMessage = "*")]
        public string Finalist1 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Finalist2 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Semifinalist1 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Semifinalist2 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Semifinalist3 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Semifinalist4 { get; set; }
        [Required(ErrorMessage = "*")]
        public string QuarterFinalist1 { get; set; }
        [Required(ErrorMessage = "*")]
        public string QuarterFinalist2 { get; set; }
        [Required(ErrorMessage = "*")]
        public string QuarterFinalist3 { get; set; }
        [Required(ErrorMessage = "*")]
        public string QuarterFinalist4 { get; set; }
        [Required(ErrorMessage = "*")]
        public string QuarterFinalist5 { get; set; }
        [Required(ErrorMessage = "*")]
        public string QuarterFinalist6 { get; set; }
        [Required(ErrorMessage = "*")]
        public string QuarterFinalist7 { get; set; }
        [Required(ErrorMessage = "*")]
        public string QuarterFinalist8 { get; set; }
        [Required(ErrorMessage = "*")]
        public string TopScorer { get; set; }
        [Required(ErrorMessage = "*")]
        public int TotalGoals { get; set; }



    }
}
