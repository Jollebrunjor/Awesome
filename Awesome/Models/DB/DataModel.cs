using System.Collections.Generic;

namespace Awesome.Models.DB
{
    using System.Data.Entity;

    public class DataModel : DbContext
    {
        static DataModel()
        {
            //Database.SetInitializer<DataModel>(null);

            Database.SetInitializer<DataModel>(new DropCreateDatabaseIfModelChanges<DataModel>());

        }


        public virtual DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

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
        public virtual ICollection<Role> Roles { get; set; }

    }
    public class Role
    {
        public int RoleId { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }

    public class UserBet
    {
        public UserBet()
        {
            Matches = new List<Match>();
        }
        public int UserBetId { get; set; }
        public ICollection<Match> Matches { get; set;}
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
        public string Finalist1Color { get; set; }
        public string Finalist2Color { get; set; }
        public string Semifinalist1Color { get; set; }
        public string Semifinalist2Color { get; set; }
        public string Semifinalist3Color { get; set; }
        public string Semifinalist4Color { get; set; }
        public string QuarterFinalist1Color { get; set; }
        public string QuarterFinalist2Color { get; set; }
        public string QuarterFinalist3Color { get; set; }
        public string QuarterFinalist4Color { get; set; }
        public string QuarterFinalist5Color { get; set; }
        public string QuarterFinalist6Color { get; set; }
        public string QuarterFinalist7Color { get; set; }
        public string QuarterFinalist8Color { get; set; }
        public string Qualified1Color { get; set; }
        public string Qualified2Color { get; set; }
        public string Qualified3Color { get; set; }
        public string Qualified4Color { get; set; }
        public string Qualified5Color { get; set; }
        public string Qualified6Color { get; set; }
        public string Qualified7Color { get; set; }
        public string Qualified8Color { get; set; }
        public string Qualified9Color { get; set; }
        public string Qualified10Color { get; set; }
        public string Qualified11Color { get; set; }
        public string Qualified12Color { get; set; }
        public string Qualified13Color { get; set; }
        public string Qualified14Color { get; set; }
        public string Qualified15Color { get; set; }
        public string Qualified16Color { get; set; }
    }


    public class Match
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


    }

    public class Result
    {
        public Result()
        {
            MatchResults = new List<MatchResult>();
        }
        public int ResultId { get; set; }
        public List<MatchResult> MatchResults { get; set; }
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

    public class MatchResult
    {
        public int MatchResultId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public string Status { get; set; }
        public bool ManuallyUpdated { get; set; }

    }

}