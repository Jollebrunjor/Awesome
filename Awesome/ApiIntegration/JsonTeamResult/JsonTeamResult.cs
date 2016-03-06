namespace Awesome.ApiIntegration.JsonTeamResult
{

    public class JsonTeamResult
    {
        public _Links _links { get; set; }
        public int count { get; set; }
        public Team[] teams { get; set; }
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

    public class Team
    {
        public _Links1 _links { get; set; }
        public string name { get; set; }
        public object code { get; set; }
        public string shortName { get; set; }
        public object squadMarketValue { get; set; }
        public string crestUrl { get; set; }
    }

    public class _Links1
    {
        public Self1 self { get; set; }
        public Fixtures fixtures { get; set; }
        public Players players { get; set; }
    }

    public class Self1
    {
        public string href { get; set; }
    }

    public class Fixtures
    {
        public string href { get; set; }
    }

    public class Players
    {
        public string href { get; set; }
    }
}