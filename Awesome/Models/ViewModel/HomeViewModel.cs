using System.Collections.Generic;
using System.Linq;
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
            Matches = TournamentUtility.CreateSchedule(groupStageMatches);
            SignupErrorMessage = "";
            LoginErrorMessage = "";

        }
        public string LoginErrorMessage { get; set; }
        public string SignupErrorMessage { get; set; }
        public UserSignUpView UserSignUpView { get; set; }
        public UserLoginView UserLoginView { get; set; }
       public List<Standing> ResultTable { get; set; }
       public List<List<Schedule>> Matches { get; set; }

    public List<Standing> GetResultTable()
        {
            
            List<Standing> resultTable = new List<Standing>();
            List<User> users = UserManager.GetUsers().Where(x => x.UserBet != null).OrderByDescending(x => x.TotalPoints).ToList();

            foreach (var user in users)
            {
                Standing standing = new Standing();

                SetNumberOfFinals(user, standing);
                SetNumberOfMatches(user, standing);
                standing.LoginName = user.LoginName;
                standing.RealName = string.Format("{0} {1}", user.FirstName, user.LastName);
                standing.TotalPoints = user.TotalPoints;
                resultTable.Add(standing);
            }
        return resultTable;
        }

        public void SetNumberOfMatches(User user, Standing standing)
        {
            int threePoints = 0;
            int onePoints = 0;
            int zeroPoints = 0;
            foreach (var match in user.UserBet.Matches)
            {
                if (match.ResultColor == "green")
                {
                    threePoints += 1;
                }
                if (match.ResultColor == "yellow")
                {
                    onePoints += 1;
                }
                if (match.ResultColor == "red")
                {
                    zeroPoints += 1;
                }
                
                standing.NumberOfThreePoints = threePoints;
                standing.NumberOfOnePoints = onePoints;
                standing.NumberOfZeroPoints = zeroPoints;

            }
        }

        private void SetNumberOfFinals(User user, Standing standing)
        {
            List<string> qualified = new List<string>()
            {
                user.UserBet.Qualified1Color,
                user.UserBet.Qualified2Color,
                user.UserBet.Qualified3Color,
                user.UserBet.Qualified4Color,
                user.UserBet.Qualified5Color,
                user.UserBet.Qualified6Color,
                user.UserBet.Qualified7Color,
                user.UserBet.Qualified8Color,
                user.UserBet.Qualified9Color,
                user.UserBet.Qualified10Color,
                user.UserBet.Qualified11Color,
                user.UserBet.Qualified12Color,
                user.UserBet.Qualified13Color,
                user.UserBet.Qualified14Color,
                user.UserBet.Qualified15Color,
                user.UserBet.Qualified16Color,
            };

            List<string> quarterfinals = new List<string>()
                {
                    user.UserBet.QuarterFinalist1Color,
                    user.UserBet.QuarterFinalist2Color,
                    user.UserBet.QuarterFinalist3Color,
                    user.UserBet.QuarterFinalist4Color,
                    user.UserBet.QuarterFinalist5Color,
                    user.UserBet.QuarterFinalist6Color,
                    user.UserBet.QuarterFinalist7Color,
                    user.UserBet.QuarterFinalist8Color,
                };
            List<string> semiFinals = new List<string>()
                {
                    user.UserBet.Semifinalist1Color,
                    user.UserBet.Semifinalist2Color,
                    user.UserBet.Semifinalist3Color,
                    user.UserBet.Semifinalist4Color,
                };

            List<string> finals = new List<string>()
                {
                    user.UserBet.Finalist1Color,
                    user.UserBet.Finalist2Color
                };

            int numberOfQualified = 0;
            foreach (var qualify in qualified)
            {
                if (qualify == "green")
                {
                    numberOfQualified += 1;
                }
            }

            int numberOfQuarterfinals = 0;
            foreach (var quarterfinal in quarterfinals)
            {
                if (quarterfinal == "green")
                {
                    numberOfQuarterfinals += 1;
                }
            }

            int numberOfSemifinals = 0;
            foreach (var semiFinal in semiFinals)
            {
                if (semiFinal == "green")
                {
                    numberOfSemifinals += 1;
                }
            }

            int numberOfFinals = 0;
            foreach (var final in finals)
            {
                if (final == "green")
                {
                    numberOfFinals += 1;
                }
            }
            standing.NumberOfQualified = numberOfQualified;
            standing.NumberOfQuarterFinals = numberOfQuarterfinals;
            standing.NumberOfSemiFinals = numberOfSemifinals;
            standing.NumberOfFinals = numberOfFinals;
        }
    }
}