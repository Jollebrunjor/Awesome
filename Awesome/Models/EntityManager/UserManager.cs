using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using Awesome.ApiIntegration.JsonGroupStageResult;
using Awesome.Models.DB;
using Awesome.Models.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Result = Awesome.Models.DB.Result;

namespace Awesome.Models.EntityManager
{
    public class UserManager
    {

        public static bool HasBetted(string userName)
        {
            using (DataModel db = new DataModel())
            {

                User user = db.Users.Include("UserBet.Matches").FirstOrDefault(o => o.LoginName == userName);

                if (user?.UserBet == null)
                    return false;
                return true;

            }
        }

        public static UserBet GetBet(string userName)
        {

            using (DataModel db = new DataModel())
            {
                User user = db.Users.Include("UserBet.Matches").FirstOrDefault(o => o.LoginName == userName);

                var userBet = user?.UserBet;
                return userBet;
            }

        }



        public static void SaveUserTotalPoints(User user, int points)
        {
            using (DataModel db = new DataModel())
            {
                User userBet = db.Users.Include("UserBet.Matches").FirstOrDefault(r => r.UserId == user.UserId);

                if (userBet != null)
                {
                    userBet.TotalPoints = points;
                }
                db.SaveChanges();
            }
        }



        public static void EditBet(UserBet bet, string userName)
        {

        }

        public static void DeleteBet(UserBet bet, string userName)
        {

        }
        public static void AddBet(UserBet bet, string userName)
        {
            using (DataModel db = new DataModel())
            {


                User user = db.Users.FirstOrDefault(o => o.LoginName == userName);

                if (user != null)
                    user.UserBet = new UserBet()
                    {
                        Finalist1 = bet.Finalist1,
                        Finalist2 = bet.Finalist2,
                        Semifinalist1 = bet.Semifinalist1,
                        Semifinalist2 = bet.Semifinalist2,
                        Semifinalist3 = bet.Semifinalist3,
                        Semifinalist4 = bet.Semifinalist4,
                        QuarterFinalist1 = bet.QuarterFinalist1,
                        QuarterFinalist2 = bet.QuarterFinalist2,
                        QuarterFinalist3 = bet.QuarterFinalist3,
                        QuarterFinalist4 = bet.QuarterFinalist4,
                        QuarterFinalist5 = bet.QuarterFinalist5,
                        QuarterFinalist6 = bet.QuarterFinalist6,
                        QuarterFinalist7 = bet.QuarterFinalist7,
                        QuarterFinalist8 = bet.QuarterFinalist8,
                        TotalGoals = bet.TotalGoals,
                        TopScorer = bet.TopScorer,
                        Matches = bet.Matches
                    };
                db.Users.AddOrUpdate(user);
                db.SaveChanges();


            }
        }



        public static void AddResult(Result result, bool manuallyUpdate)
        {
            result.ResultId = 1;
            using (DataModel db = new DataModel())
            {
                Result existingResult = db.Results.Include("MatchResults").FirstOrDefault(r => r.ResultId == result.ResultId);

                if (existingResult != null)
                {

                    foreach (var newMatch in result.MatchResults)
                    {
                        foreach (var oldMatch in existingResult.MatchResults.Where(x => x.MatchResultId == newMatch.MatchResultId))
                        {
                            if (oldMatch.ManuallyUpdated && !manuallyUpdate)
                            {
                                break;
                            }

                            if (manuallyUpdate)
                            {
                                if (oldMatch.AwayScore != newMatch.AwayScore ||
                                    oldMatch.HomeScore != newMatch.HomeScore)
                                {
                                    oldMatch.ManuallyUpdated = true;
                                }
                            }
                            oldMatch.AwayScore = newMatch.AwayScore;
                            oldMatch.AwayTeam = newMatch.AwayTeam;
                            oldMatch.HomeScore = newMatch.HomeScore;
                            oldMatch.HomeTeam = newMatch.HomeTeam;


                        }

                    }
                    if (manuallyUpdate)
                    {
                        existingResult.Finalist1 = result.Finalist1;
                        existingResult.Finalist2 = result.Finalist2;
                        existingResult.Semifinalist1 = result.Semifinalist1;
                        existingResult.Semifinalist2 = result.Semifinalist2;
                        existingResult.Semifinalist3 = result.Semifinalist3;
                        existingResult.Semifinalist4 = result.Semifinalist4;
                        existingResult.QuarterFinalist1 = existingResult.QuarterFinalist1;
                        existingResult.QuarterFinalist2 = existingResult.QuarterFinalist2;
                        existingResult.QuarterFinalist3 = existingResult.QuarterFinalist3;
                        existingResult.QuarterFinalist4 = existingResult.QuarterFinalist4;
                        existingResult.QuarterFinalist5 = existingResult.QuarterFinalist5;
                        existingResult.QuarterFinalist6 = existingResult.QuarterFinalist6;
                        existingResult.QuarterFinalist7 = existingResult.QuarterFinalist7;
                        existingResult.QuarterFinalist8 = existingResult.QuarterFinalist8;
                        existingResult.TopScorer = result.TopScorer;
                        existingResult.TotalGoals = result.TotalGoals;
                    }


                    db.SaveChanges();
                }
                else
                {
                    db.Results.AddOrUpdate(result);
                    db.SaveChanges();
                }
            }
        }

        public static Result GetResult()
        {
            using (DataModel db = new DataModel())
            {
                Result result = db.Results.Include("MatchResults").FirstOrDefault();
                
                return result;
            }

        }

        public void AddUserAccount(UserSignUpView currentUser)
        {

            using (DataModel db = new DataModel())
            {

                User user = new User();


                user.LoginName = currentUser.LoginName;
                user.Password = currentUser.Password;
                user.FirstName = currentUser.FirstName;
                user.LastName = currentUser.LastName;
                user.UserId = currentUser.UserId;
                //TABORT     var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(db));

                db.Users.Add(user);
                db.SaveChanges();
            }

        }

        public bool IsLoginNameExist(string loginName)
        {
            using (DataModel db = new DataModel())
            {
                return db.Users.Any(o => o.LoginName.Equals(loginName));
            }
        }

        public static List<User> GetUsers()
        {
            using (DataModel db = new DataModel())
            {
                if (db.Users != null)
                    return db.Users.Include("UserBet.Matches").ToList();
                return new List<User>();
            }

        }

        public string GetUserPassword(string loginName)
        {
            using (DataModel db = new DataModel())
            {

                var test = db.Users;

                var hej = test.Local.Count;
                var user = test.Where(o => o.LoginName.ToLower().Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault()?.Password;
                else
                    return string.Empty;
            }
        }

        public static void SetMatchColor(Match match, User user)
        {
            using (DataModel db = new DataModel())
            {
                User selecteduser = db.Users.Include("UserBet.Matches").FirstOrDefault(x => x.UserId == user.UserId);

                Match selectedmatch = selecteduser?.UserBet.Matches.FirstOrDefault(x => x.MatchId == match.MatchId);

                if (selectedmatch != null)
                    selectedmatch.ResultColor = match.ResultColor;
                db.SaveChanges();

            }
        }

        public static void SetFinalistsColor(User user, List<string> correctFinalists, List<string> correctSemifinalists, List<string> correctQuarterfinalists)
        {
            using (DataModel db = new DataModel())
            {
                User selecteduser = db.Users.Include("UserBet").FirstOrDefault(x => x.UserId == user.UserId);

                foreach (var finalist in correctFinalists)
                {
                    if (finalist == selecteduser.UserBet.Finalist1)
                        selecteduser.UserBet.Finalist1Color = "green";
                    if (finalist == selecteduser.UserBet.Finalist2)
                        selecteduser.UserBet.Finalist2Color = "green";
                }

                foreach (var semifinalist in correctSemifinalists)
                {
                    if (semifinalist == selecteduser.UserBet.Semifinalist1)
                        selecteduser.UserBet.Semifinalist1Color = "green";
                    if (semifinalist == selecteduser.UserBet.Semifinalist2)
                        selecteduser.UserBet.Semifinalist2Color = "green";
                    if (semifinalist == selecteduser.UserBet.Semifinalist3)
                        selecteduser.UserBet.Semifinalist3Color = "green";
                    if (semifinalist == selecteduser.UserBet.Semifinalist4)
                        selecteduser.UserBet.Semifinalist4Color = "green";
                }

                foreach (var quarterfinalist in correctQuarterfinalists)
                {
                    if (quarterfinalist == selecteduser.UserBet.QuarterFinalist1)
                        selecteduser.UserBet.QuarterFinalist1Color = "green";
                    if (quarterfinalist == selecteduser.UserBet.QuarterFinalist2)
                        selecteduser.UserBet.QuarterFinalist2Color = "green";
                    if (quarterfinalist == selecteduser.UserBet.QuarterFinalist3)
                        selecteduser.UserBet.QuarterFinalist3Color = "green";
                    if (quarterfinalist == selecteduser.UserBet.QuarterFinalist4)
                        selecteduser.UserBet.QuarterFinalist4Color = "green";
                    if (quarterfinalist == selecteduser.UserBet.QuarterFinalist5)
                        selecteduser.UserBet.QuarterFinalist5Color = "green";
                    if (quarterfinalist == selecteduser.UserBet.QuarterFinalist6)
                        selecteduser.UserBet.QuarterFinalist6Color = "green";
                    if (quarterfinalist == selecteduser.UserBet.QuarterFinalist7)
                        selecteduser.UserBet.QuarterFinalist7Color = "green";
                    if (quarterfinalist == selecteduser.UserBet.QuarterFinalist8)
                        selecteduser.UserBet.QuarterFinalist8Color = "green";
                }

                db.SaveChanges();

            }
        }
    }
}


