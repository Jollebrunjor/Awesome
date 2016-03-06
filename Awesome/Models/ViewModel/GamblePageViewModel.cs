
using System.Collections.Generic;
using System.Linq;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;

namespace Awesome.Models.ViewModel
{
    public class GamblePageViewModel
    {
        public GamblePageViewModel(JsonTeamResult teams, JsonGroupStageResult groupStageResult)
        {
            Teams = GetTeams(teams); 
            GroupStageMatches = GetGroupStageMatches(groupStageResult);
        }

        public Dictionary<int, Fixture> GroupStageMatches { get; set; } 
        public List<Team> Teams { get; set; }

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