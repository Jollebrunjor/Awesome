using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.Models.DB;
using Awesome.Models.EntityManager;

namespace Awesome.Models.ViewModel
{
    public class HomeViewModel
    {
        public HomeViewModel(JsonGroupStageResult groupStageMatches)
        {
            ResultTable = GetResultTable();
            UserLoginView = new UserLoginView();
            UserSignUpView = new UserSignUpView();
            Matches = TournamentUtility.CreateMatchList(groupStageMatches);
            SignupErrorMessage = string.Empty;
            LoginErrorMessage = string.Empty;

        }
        public object LoginErrorMessage { get; set; }
        public object SignupErrorMessage { get; set; }
        public UserSignUpView UserSignUpView { get; set; }
        public UserLoginView UserLoginView { get; set; }
       public Dictionary<string, int> ResultTable { get; set; }
       public List<Match> Matches { get; set; }

    public Dictionary<string, int> GetResultTable()
        {
            Dictionary<string, int> resultTable = new Dictionary<string, int>();
            List<User> users = UserManager.GetUsers().Where(x => x.UserBet != null).OrderByDescending(x => x.TotalPoints).ToList();

            foreach (var user in users)
            {
                resultTable.Add(user.LoginName, user.TotalPoints);
            }

        return resultTable;

        } 
    }
}