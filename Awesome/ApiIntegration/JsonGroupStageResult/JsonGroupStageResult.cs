using System;


namespace Awesome.ApiIntegration.JsonGroupStageResult
{
    public class JsonGroupStageResult
    {
            public _Links _links { get; set; }
            public int count { get; set; }
            public Fixture[] fixtures { get; set; }
        }

        public class _Links
        {
            public Self self { get; set; }
            public Soccerseason soccerseason { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Soccerseason
        {
            public string href { get; set; }
        }

        public class Fixture
        {
            public _Links1 _links { get; set; }
            public DateTime date { get; set; }
            public string status { get; set; }
            public int matchday { get; set; }
            public string homeTeamName { get; set; }
            public string awayTeamName { get; set; }
            public Result result { get; set; }
        }

        public class _Links1
        {
            public Self1 self { get; set; }
            public Soccerseason1 soccerseason { get; set; }
            public Hometeam homeTeam { get; set; }
            public Awayteam awayTeam { get; set; }
        }

        public class Self1
        {
            public string href { get; set; }
        }

        public class Soccerseason1
        {
            public string href { get; set; }
        }

        public class Hometeam
        {
            public string href { get; set; }
        }

        public class Awayteam
        {
            public string href { get; set; }
        }

        public class Result
        {
            public int? goalsHomeTeam { get; set; }
            public int? goalsAwayTeam { get; set; }
        }
  
}