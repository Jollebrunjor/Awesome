﻿
using System.Collections.Generic;
using System.Linq;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Awesome.Models.DB;
using Awesome.Models.EntityManager;
using Match = Awesome.Models.DB.Match;

namespace Awesome.Models.ViewModel
{
    public class MyPageViewModel
    {
        public MyPageViewModel()
        {
            
        }

        public MyPageViewModel(JsonTeamResult teams, JsonGroupStageResult groupStageMatches, string userName)
        {

            Teams = TournamentUtility.CreateTeamList(teams);
            CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
            HasBetted = UserManager.HasBetted(CurrentUser);
            Matches = TournamentUtility.CreateMatchList(groupStageMatches);
            Bet = new Bet(groupStageMatches);
            Result = ResultsInVMyPage();
            CurrentUserBet = GetBetForCurrentUser(CurrentUser);
            OtherUsersBet = GetOtherUsersBet();
            ResultList = GetResultList(CurrentUserBet);
            UserBet = GetBetForCurrentUser(userName);
            OtherBet = userName != null;
            UserName = userName + "s";

        }

       public string UserName { get; set; }
        public bool OtherBet { get; set; }
        public bool HasBetted { get; set; }
        public Dictionary<int, ApiIntegration.JsonGroupStageResult.Match> GroupStageMatches { get; set; }
        public List<Team> Teams { get; set; }
        public string CurrentUser { get; set; }
        public Bet Bet { get; set; }
        public List<Match> Matches { get; set; }
        public DB.Result Result { get; set; } 
        public List<string> ResultList { get; set; }
        public List<User> OtherUsersBet { get; set; }
        public UserBet CurrentUserBet { get; set; }
        public UserBet UserBet { get; set; }

        public DB.Result ResultsInVMyPage()
        {

            DB.Result result = UserManager.GetResult();
            if (result?.MatchResults != null)
            foreach (var match in result.MatchResults)
            {
                if (match.Status == "SCHEDULED")
                {
                    match.Status = "Ej spelad";
                }
                if (match.Status == "FINISHED")
                {
                    match.Status = "Färdigspelad";
                }
                if (match.Status == "IN_PLAY")
                {
                    match.Status = "Pågår";
                }
            }
            return result;
        }

        public UserBet GetBetForCurrentUser(string user)
        {
            return UserManager.GetBet(user);
        }

        public List<User> GetOtherUsersBet()
        {
            return UserManager.GetUsers().Where(x => x.LoginName != CurrentUser && x.UserBet != null).ToList();
        }

        public List<string> GetResultList(UserBet currentUserbet)
        {
            FootballApiClient client = new FootballApiClient();

            List<string> currentUserMatchBet = new List<string>();


            if (currentUserbet != null)
                foreach (var match in currentUserbet.Matches)
                {
                    currentUserMatchBet.Add(match.HomeTeam + match.AwayTeam);
                }


            return client.GetResults(currentUserMatchBet);
        }

    }


}