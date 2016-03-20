﻿
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Awesome.Models.DB;
using Awesome.Models.EntityManager;


namespace Awesome.Models.ViewModel
{
    public class MyPageViewModel
    {
        public MyPageViewModel()
        {
            
        }

        public MyPageViewModel(JsonTeamResult teams, JsonGroupStageResult groupStageMatches)
        {
            Teams = TournamentUtility.CreateTeamList(teams);
            CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
            HasBetted = UserManager.HasBetted(CurrentUser);
            Matches = TournamentUtility.CreateMatchList(groupStageMatches);
            Bet = new Bet(groupStageMatches);
           
            CurrentUserBet = GetBetForCurrentUser(CurrentUser);
            OtherUsersBet = GetOtherUsersBet();
            ResultList = GetResultList(CurrentUserBet);
        }


        public bool HasBetted { get; set; }
        public Dictionary<int, Fixture> GroupStageMatches { get; set; }
        public List<Team> Teams { get; set; }
        public string CurrentUser { get; set; }
        public Bet Bet { get; set; }
        public List<Fixture> Matches { get; set; }

        public List<string> ResultList { get; set; }
        public List<User> OtherUsersBet { get; set; }
        public UserBet CurrentUserBet { get; set; }

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