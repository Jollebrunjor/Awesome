using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Web.DynamicData;
using System.Web.Services.Protocols;
using System.Web.UI;
using Awesome.Models.ViewModel;

namespace Awesome.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataModel : DbContext
    {
        static DataModel()
        {
            Database.SetInitializer<DataModel>(null);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<UserBet> UserBet { get; set; }
    }

    public class User 
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalPoints { get; set; }
        public UserBet UserBet { get; set; }
     
    }

    public class UserBet
    {
        public UserBet()
        {
            Matches = new List<Match>();
        }
        public int UserBetId { get; set; }
        public ICollection<Match> Matches { get; set; }
        public string Finalist1 { get; set; }
        public string Finalist2 { get; set; }
        public string Semifinalist1 { get; set; }
        public string Semifinalist2 { get; set; }
        public string TopScorer { get; set; }

    }


    public class Match
    {
        public int MatchId { get; set; }
        public int MatchNumber { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public Result Result { get; set; }
    }

    public class Result
    {
        public Result()
        {
            MatchResults = new List<MatchResult>();
        }
        public int ResultId { get; set; }
        public ICollection<MatchResult> MatchResults { get; set; }
        public string Finalist1 { get; set; }
        public string Finalist2 { get; set; }
        public string Semifinalist1 { get; set; }
        public string Semifinalist2 { get; set; }
        public string TopScorer { get; set; }
    }

    public class MatchResult
    {
        public int MatchResultId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public Result Result { get; set; }
    }

}