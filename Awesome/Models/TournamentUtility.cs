using System;
using System.Collections.Generic;
using System.Linq;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Awesome.Models.DB;
using Match = Awesome.Models.DB.Match;

namespace Awesome.Models
{
    public class TournamentUtility
    {
        // Methods
        public static List<Match> CreateMatchList(Awesome.ApiIntegration.JsonGroupStageResult.JsonGroupStageResult groupStageMatches)
        {
            if (groupStageMatches.matches == null)
            {
                return new List<Match>();
            }
            List<Match> list = new List<Match>();
            int num = 1;
            foreach (ApiIntegration.JsonGroupStageResult.Match match in groupStageMatches.matches)
            {
                if (match.stage == "GROUP_STAGE")
                {
                    Match match1 = new Match
                    {
                        HomeTeam = match.homeTeam.name,
                        AwayTeam = match.awayTeam.name
                    };
                    object goalsHomeTeam = match.score.fullTime.homeTeam;
                    match1.HomeScore = goalsHomeTeam != null ? Convert.ToInt32(goalsHomeTeam) : 0;
                    object goalsAwayTeam = match.score.fullTime.awayTeam;
                    match1.AwayScore = goalsAwayTeam != null ? Convert.ToInt32(goalsHomeTeam) : 0;
                    match1.MatchId = num++;
                    match1.Status = match.status;
                    match1.Date = match.utcDate.ToLongDateString();
                    match1.Matchday = match.matchday;
                    Match item = match1;
                    list.Add(item);
                }
            }
            return list;
        }

        public static List<List<Schedule>> CreateSchedule(Awesome.ApiIntegration.JsonGroupStageResult.JsonGroupStageResult groupStageMatches)
        {
            if (groupStageMatches.matches == null)
            {
                return new List<List<Schedule>>();
            }
            List<Schedule> list = new List<Schedule>();
            int num = 1;
            foreach (var match in groupStageMatches.matches.Where(x => x.stage == "GROUP_STAGE"))
            {
                Schedule schedule1 = new Schedule();

                    schedule1.HomeTeam = match.homeTeam.name;
                    schedule1.AwayTeam = match.awayTeam.name;

                object goalsHomeTeam = match.score.fullTime.homeTeam;
                schedule1.HomeScore = goalsHomeTeam != null ? Convert.ToInt32(goalsHomeTeam) : 0;
                object goalsAwayTeam = match.score.fullTime.awayTeam;
                schedule1.AwayScore = goalsAwayTeam != null ? Convert.ToInt32(goalsHomeTeam) : 0;

                schedule1.MatchId = num++;
                schedule1.Status = match.status;
                schedule1.Date = match.utcDate.ToString("MMMM dd");
                schedule1.Matchday = match.matchday;
                schedule1.Time = match.utcDate.AddHours(2.0).ToString("H:mm");
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