using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awesome.Models
{
    public class Schedule
    {
        public int MatchId { get; set; }
        public string ResultColor { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public string Status { get; set; }
        public int Matchday { get; set; }
        public string Date { get; set; }

        public string Time { get; set; }
    }
}