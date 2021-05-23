using System;


namespace Awesome.ApiIntegration.JsonGroupStageResult
{

    using System;

    public class JsonGroupStageResult
    {
        public int count { get; set; }
        public Filters filters { get; set; }
        public Competition competition { get; set; }
        public Match[] matches { get; set; }
    }

    public class Filters
    {
    }

    public class Competition
    {
        public int id { get; set; }
        public Area area { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string plan { get; set; }
        public DateTime lastUpdated { get; set; }
    }

    public class Area
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Match
    {
        public int id { get; set; }
        public Season season { get; set; }
        public DateTime utcDate { get; set; }
        public string status { get; set; }
        public int matchday { get; set; }
        public string stage { get; set; }
        public string group { get; set; }
        public DateTime lastUpdated { get; set; }
        public Odds odds { get; set; }
        public Score score { get; set; }
        public Hometeam homeTeam { get; set; }
        public Awayteam awayTeam { get; set; }
        public object[] referees { get; set; }
    }

    public class Season
    {
        public int id { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int currentMatchday { get; set; }
    }

    public class Odds
    {
        public string msg { get; set; }
    }

    public class Score
    {
        public object winner { get; set; }
        public string duration { get; set; }
        public Fulltime fullTime { get; set; }
        public Halftime halfTime { get; set; }
        public Extratime extraTime { get; set; }
        public Penalties penalties { get; set; }
    }

    public class Fulltime
    {
        public object homeTeam { get; set; }
        public object awayTeam { get; set; }
    }

    public class Halftime
    {
        public object homeTeam { get; set; }
        public object awayTeam { get; set; }
    }

    public class Extratime
    {
        public object homeTeam { get; set; }
        public object awayTeam { get; set; }
    }

    public class Penalties
    {
        public object homeTeam { get; set; }
        public object awayTeam { get; set; }
    }

    public class Hometeam
    {
        public int? id { get; set; }
        public string name { get; set; }
    }

    public class Awayteam
    {
        public int? id { get; set; }
        public string name { get; set; }
    }


}