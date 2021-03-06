﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.Models.DB;
using Match = Awesome.Models.DB.Match;

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
        public string Qualified1 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified2 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified3 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified4 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified5 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified6 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified7 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified8 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified9 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified10 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified11 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified12 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified13 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified14 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified15 { get; set; }
        [Required(ErrorMessage = "*")]
        public string Qualified16 { get; set; }

        public string TopScorer { get; set; }
        [Required(ErrorMessage = "*")]
        public int TotalGoals { get; set; }



    }
}
