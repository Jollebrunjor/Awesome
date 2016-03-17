
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
    public class PlaceBetPageViewModel
    {
        public PlaceBetPageViewModel()
        {
            
        }

        public PlaceBetPageViewModel(JsonTeamResult teams, JsonGroupStageResult groupStageResult)
        {
            Teams = GetTeams(teams);
            GroupStageMatches = GetGroupStageMatches(groupStageResult);
            CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
            HasBetted = UserManager.HasBetted(CurrentUser);
            Matches = GetMatches(groupStageResult);
            Bet = new Bet(groupStageResult);
        }


        public bool HasBetted { get; set; }
        public Dictionary<int, Fixture> GroupStageMatches { get; set; }
        public List<Team> Teams { get; set; }
        public string CurrentUser { get; set; }

        public Bet Bet { get; set; }
        public List<Fixture> Matches { get; set; } 





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

        public List<Fixture> GetMatches(JsonGroupStageResult groupStageResult)
        {
            List<Fixture> groupStageMatches = new List<Fixture>();
           
            foreach (var match in groupStageResult.fixtures)
            {
 
                groupStageMatches.Add(match);

            }
            return groupStageMatches;
        }

        public List<Team> GetTeams(JsonTeamResult teams)
        {
            return teams.teams?.ToList();
        }     
    }


}