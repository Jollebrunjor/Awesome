namespace Awesome.Models
{
    using Awesome.Models.DB;
    using Awesome.Models.EntityManager;
    using System.Collections.Generic;
    using System.Linq;

    public class ScheduledTasks
    {
        public static void AddPointsToAllUsers()
        {
            Awesome.Models.DB.Result result = UserManager.GetResult();
            foreach (User user in from x in UserManager.GetUsers()
                                  where x.UserBet != null
                                  select x)
            {
                int points = 0;
                foreach (MatchResult r in from x in result.MatchResults
                                          where x.Status == "SCHEDULED"
                                          select x)
                {

                    foreach (Match match in user.UserBet.Matches.Where<Match>((x => (x.HomeTeam == r.HomeTeam) && (x.AwayTeam == r.AwayTeam))))
                    {
                        if ((match.HomeScore == r.HomeScore) && (match.AwayScore == r.AwayScore))
                        {
                            match.ResultColor = "green";
                            points += 3;
                        }
                        else if ((match.HomeScore > match.AwayScore) && (r.HomeScore > r.AwayScore))
                        {
                            points++;
                            match.ResultColor = "yellow";
                        }
                        else if ((match.HomeScore < match.AwayScore) && (r.HomeScore < r.AwayScore))
                        {
                            points++;
                            match.ResultColor = "yellow";
                        }
                        else if ((match.HomeScore == match.AwayScore) && (r.HomeScore == r.AwayScore))
                        {
                            points++;
                            match.ResultColor = "yellow";
                        }
                        else
                        {
                            points += 0;
                            match.ResultColor = "red";
                        }
                        UserManager.SetMatchColor(match, user);
                    }
                }
                List<string> correctFinalists = UpdateFinalists(user, result);
                List<string> correctSemifinalists = UpdateSemiFinalists(user, result);
                List<string> correctQuarterfinalists = UpdateQuarterFinalists(user, result);
                List<string> correctQualified = UpdateQualified(user, result);
                UserManager.SetFinalistsColor(user, correctFinalists, correctSemifinalists, correctQuarterfinalists, correctQualified);
                points += correctFinalists.Count * 7;
                points += correctSemifinalists.Count * 5;
                points += correctQuarterfinalists.Count * 3;
                points += correctQualified.Count * 2;
                UserManager.SaveUserTotalPoints(user, points);
            }
        }

        public static void AutomaticUpdateResults()
        {
            Awesome.Models.DB.Result currentResult = UserManager.GetResult();
            if (currentResult == null)
            {
                CreateMatchResultTable();
            }
            else
            {
                Awesome.ApiIntegration.JsonGroupStageResult.JsonGroupStageResult groupStageMatches = new FootballApiClient().GetGroupStageMatches();
                if (groupStageMatches == null)
                {
                    AutomaticUpdateResultsFromDb(currentResult);
                }
                else
                {
                    Awesome.Models.DB.Result result = new Awesome.Models.DB.Result();
                    foreach (Match match in TournamentUtility.CreateMatchList(groupStageMatches))
                    {
                        if (match.Status == "SCHEDULED")
                        {
                            MatchResult item = new MatchResult
                            {
                                HomeTeam = match.HomeTeam,
                                AwayTeam = match.AwayTeam,
                                HomeScore = match.HomeScore,
                                AwayScore = match.AwayScore,
                                MatchResultId = match.MatchId,
                                Status = match.Status,
                                ManuallyUpdated = false
                            };
                            result.MatchResults.Add(item);
                        }
                    }
                    UserManager.AddResult(result, false);
                }
            }
        }

        private static void AutomaticUpdateResultsFromDb(Awesome.Models.DB.Result currentResult)
        {
            Awesome.Models.DB.Result result = new Awesome.Models.DB.Result();
            foreach (MatchResult result2 in currentResult.MatchResults)
            {
                if ((result2.Status == "SCHEDULED") && !result2.ManuallyUpdated)
                {
                    MatchResult item = new MatchResult
                    {
                        HomeTeam = result2.HomeTeam,
                        AwayTeam = result2.AwayTeam,
                        HomeScore = result2.HomeScore,
                        AwayScore = result2.AwayScore,
                        MatchResultId = result2.MatchResultId,
                        Status = result2.Status,
                        ManuallyUpdated = false
                    };
                    result.MatchResults.Add(item);
                }
            }
            UserManager.AddResult(result, false);
        }

        private static void CreateMatchResultTable()
        {
            Awesome.Models.DB.Result result = new Awesome.Models.DB.Result();
            foreach (Match match in TournamentUtility.CreateMatchList(new FootballApiClient().GetGroupStageMatches()))
            {
                MatchResult item = new MatchResult
                {
                    HomeTeam = match.HomeTeam,
                    AwayTeam = match.AwayTeam,
                    HomeScore = match.HomeScore,
                    AwayScore = match.AwayScore,
                    MatchResultId = match.MatchId,
                    Status = match.Status,
                    ManuallyUpdated = false
                };
                result.MatchResults.Add(item);
            }
            UserManager.AddResult(result, false);
        }

        private static List<string> UpdateFinalists(User user, Awesome.Models.DB.Result result)
        {
            List<string> list = new List<string> {
                user.UserBet.Finalist1,
                user.UserBet.Finalist2
            };
            List<string> list3 = new List<string> {
                result.Finalist1,
                result.Finalist2
            };
            List<string> list2 = new List<string>();
            foreach (string str in list3)
            {
                foreach (string str2 in list)
                {
                    if ((str2 != null) && (str2 == str))
                    {
                        list2.Add(str2);
                    }
                }
            }
            return list2;
        }
        private static List<string> UpdateQualified(User user, Awesome.Models.DB.Result result)
        {
            List<string> list = new List<string> {
                user.UserBet.Qualified1,
                user.UserBet.Qualified2,
                user.UserBet.Qualified3,
                user.UserBet.Qualified4,
                user.UserBet.Qualified5,
                user.UserBet.Qualified6,
                user.UserBet.Qualified7,
                user.UserBet.Qualified8,
                user.UserBet.Qualified9,
                user.UserBet.Qualified10,
                user.UserBet.Qualified11,
                user.UserBet.Qualified12,
                user.UserBet.Qualified13,
                user.UserBet.Qualified14,
                user.UserBet.Qualified15,
                user.UserBet.Qualified16,
            };
            List<string> list3 = new List<string> {
                result.Qualified1,
                result.Qualified2,
                result.Qualified3,
                result.Qualified4,
                result.Qualified5,
                result.Qualified6,
                result.Qualified7,
                result.Qualified8,
                result.Qualified9,
                result.Qualified10,
                result.Qualified11,
                result.Qualified12,
                result.Qualified13,
                result.Qualified14,
                result.Qualified15,
                result.Qualified16,


            };
            List<string> list2 = new List<string>();
            foreach (string str in list3)
            {
                foreach (string str2 in list)
                {
                    if ((str2 != null) && (str2 == str))
                    {
                        list2.Add(str2);
                    }
                }
            }
            return list2;
        }

        private static List<string> UpdateQuarterFinalists(User user, Awesome.Models.DB.Result result)
        {
            List<string> list = new List<string> {
                user.UserBet.QuarterFinalist1,
                user.UserBet.QuarterFinalist2,
                user.UserBet.QuarterFinalist3,
                user.UserBet.QuarterFinalist4,
                user.UserBet.QuarterFinalist5,
                user.UserBet.QuarterFinalist6,
                user.UserBet.QuarterFinalist7,
                user.UserBet.QuarterFinalist8
            };
            List<string> list3 = new List<string> {
                result.QuarterFinalist1,
                result.QuarterFinalist2,
                result.QuarterFinalist3,
                result.QuarterFinalist4,
                result.QuarterFinalist5,
                result.QuarterFinalist6,
                result.QuarterFinalist7,
                result.QuarterFinalist8
            };
            List<string> list2 = new List<string>();
            foreach (string str in list3)
            {
                foreach (string str2 in list)
                {
                    if ((str2 != null) && (str2 == str))
                    {
                        list2.Add(str2);
                    }
                }
            }
            return list2;
        }

        private static List<string> UpdateSemiFinalists(User user, Awesome.Models.DB.Result result)
        {
            List<string> list = new List<string> {
                user.UserBet.Semifinalist1,
                user.UserBet.Semifinalist2,
                user.UserBet.Semifinalist3,
                user.UserBet.Semifinalist4
            };
            List<string> list3 = new List<string> {
                result.Semifinalist1,
                result.Semifinalist2,
                result.Semifinalist3,
                result.Semifinalist4
            };
            List<string> list2 = new List<string>();
            foreach (string str in list3)
            {
                foreach (string str2 in list)
                {
                    if ((str2 != null) && (str2 == str))
                    {
                        list2.Add(str2);
                    }
                }
            }
            return list2;

        }
    }
}
