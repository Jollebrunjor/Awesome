using Awesome.Models.DB;

namespace Awesome.Models.ViewModel
{
    using Awesome.ApiIntegration.JsonTeamResult;
    using Awesome.Models;
    using Awesome.Models.EntityManager;
    using System.Collections.Generic;

    public class AdminViewModel
    {
        public AdminViewModel()
        {
        }

        public AdminViewModel(Awesome.ApiIntegration.JsonTeamResult.JsonTeamResult teams, Awesome.ApiIntegration.JsonGroupStageResult.JsonGroupStageResult groupStageMatches)
        {
            this.ReportedResult = new Awesome.Models.ReportedResult(groupStageMatches);
            this.Teams = TournamentUtility.CreateTeamList(teams);
            this.Result = UserManager.GetResult();
            this.Users = UserManager.GetUsers();
        }

        public Awesome.Models.ReportedResult ReportedResult { get; set; }

        public List<Team> Teams { get; set; }

        public bool HasReported { get; set; }

        public Awesome.Models.DB.Result Result { get; set; }
        public List<User> Users { get; set; }
        public User User { get; set; }
    }
}
