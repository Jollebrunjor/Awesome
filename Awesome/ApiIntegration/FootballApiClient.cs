using System;
using System.Collections.Generic;
using System.Net;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.ApiIntegration.JsonTeamResult;
using Newtonsoft.Json;

namespace Awesome.Models
{
    public class FootballApiClient
    {
        public JsonGroupStageResult GetGroupStageMatches()
        {

            var url = "http://api.football-data.org/v1/soccerseasons/424/fixtures";
            var groupstagematches = _download_serialized_json_data<JsonGroupStageResult>(url);

            return groupstagematches;
        }

        public JsonTeamResult GetTeams()
        {
            var url = "http://api.football-data.org/v1/soccerseasons/424/teams";
            JsonTeamResult teams = _download_serialized_json_data<JsonTeamResult>(url);

            return teams;
        }

        public List<string> GetResults(List<string> teamList)
        {
            List<string> results = new List<string>();
            var matches = GetGroupStageMatches();
            var fixtures = matches.fixtures;
            if (fixtures != null)
            {
                foreach (var f in fixtures)
                {
                    string match = f.homeTeamName + f.awayTeamName;
                    if (teamList.Contains(match))
                    {
                        results.Add(f.result.goalsHomeTeam + "-" + f.result.goalsAwayTeam);
                    }
                }
            }
            return results;
        }


        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            string apiKey = "cb605b1101d342efba66b2ccbeb8dc2d";
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                try
                {
                    w.Headers.Add("X-Auth-Token", apiKey);
                    json_data = w.DownloadString(url);
                }

                catch (Exception) { }
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }


}