
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Awesome.Models.DB;
using Awesome.Models.EntityManager;

namespace Awesome.Models.ViewModel
{
    public class PlaceBetPageViewModel
    {
        public PlaceBetPageViewModel(JsonTeamResult teams, JsonGroupStageResult groupStageResult)

        {
            Teams = GetTeams(teams); 
            GroupStageMatches = GetGroupStageMatches(groupStageResult);
            CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
            HasBetted = UserManager.HasBetted(CurrentUser);

        }


        public bool HasBetted { get; set; }
        public Dictionary<int, Fixture> GroupStageMatches { get; set; } 
        public List<Team> Teams { get; set; }
        public string CurrentUser { get; set; }

        public Dictionary<int, Fixture> GetGroupStageMatches(JsonGroupStageResult groupStageResult)
        {
            Dictionary<int, Fixture> groupStageMatches = new Dictionary<int, Fixture>();
            int index = 0;
            foreach (var match in groupStageResult.fixtures)
            {
                index ++;
                groupStageMatches.Add(index, match);
                
            }
            return groupStageMatches;
        }

        public List<Team> GetTeams(JsonTeamResult team)
        {
            return team.teams?.ToList();
        }
    }
}