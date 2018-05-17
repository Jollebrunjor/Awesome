using System.Collections.Generic;
using System.Linq;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Awesome.Models.DB;

namespace Awesome.Models
{
    public class TournamentUtility
    {
        // Methods
        public static List<Match> CreateMatchList(Awesome.ApiIntegration.JsonGroupStageResult.JsonGroupStageResult groupStageMatches)
        {
            if (groupStageMatches.fixtures == null)
            {
                return new List<Match>();
            }
            List<Match> list = new List<Match>();
            int num = 1;
            foreach (Fixture fixture in groupStageMatches.fixtures)
            {
                if (fixture.status != "SCHEDULED")
                {
                    Match match1 = new Match
                    {
                        HomeTeam = fixture.homeTeamName,
                        AwayTeam = fixture.awayTeamName
                    };
                    int? goalsHomeTeam = fixture.result.goalsHomeTeam;
                    match1.HomeScore = goalsHomeTeam.HasValue ? goalsHomeTeam.GetValueOrDefault() : 0;
                    goalsHomeTeam = fixture.result.goalsAwayTeam;
                    match1.AwayScore = goalsHomeTeam.HasValue ? goalsHomeTeam.GetValueOrDefault() : 0;
                    match1.MatchId = num++;
                    match1.Status = fixture.status;
                    match1.Date = fixture.date.ToLongDateString();
                    match1.Matchday = fixture.matchday;
                    Match item = match1;
                    list.Add(item);
                }
            }
            return list;
        }

        public static List<List<Schedule>> CreateSchedule(Awesome.ApiIntegration.JsonGroupStageResult.JsonGroupStageResult groupStageMatches)
        {
            if (groupStageMatches.fixtures == null)
            {
                return new List<List<Schedule>>();
            }
            List<Schedule> list = new List<Schedule>();
            int num = 1;
            foreach (Fixture fixture in groupStageMatches.fixtures)
            {
                Schedule schedule1 = new Schedule();
                if (fixture.status == "SCHEDULED")
                {
                    schedule1.HomeTeam = "TBD";
                    schedule1.AwayTeam = "TBD";
                }
                else
                {
                    schedule1.HomeTeam = fixture.homeTeamName;
                    schedule1.AwayTeam = fixture.awayTeamName;
                }

                int? goalsHomeTeam = fixture.result.goalsHomeTeam;
                schedule1.HomeScore = goalsHomeTeam.HasValue ? goalsHomeTeam.GetValueOrDefault() : 0;
                goalsHomeTeam = fixture.result.goalsAwayTeam;
                schedule1.AwayScore = goalsHomeTeam.HasValue ? goalsHomeTeam.GetValueOrDefault() : 0;
                schedule1.MatchId = num++;
                schedule1.Status = fixture.status;
                schedule1.Date = fixture.date.ToString("MMMM dd");
                schedule1.Matchday = fixture.matchday;
                schedule1.Time = fixture.date.AddHours(2.0).ToString("H:mm");
                Schedule item = schedule1;
                list.Add(item);
            }
            return (from u in list
                    group u by u.Date into g
                    select g.ToList<Schedule>()).ToList<List<Schedule>>();
        }

        public static List<Team> CreateTeamList(Awesome.ApiIntegration.JsonTeamResult.JsonTeamResult teams)
        {
            Team[] source = teams.teams;
            if (source == null)
            {
                return null;
            }
            return source.ToList<Team>();
        }
    }
}