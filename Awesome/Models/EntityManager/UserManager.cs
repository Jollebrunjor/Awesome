using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using Awesome.Models.DB;
using Awesome.Models.ViewModel;
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
        public static List<User> GetUsersWithNoBet()
        {
            using (DataModel db = new DataModel())
            {
                if (db.Users != null)
                    return db.Users.Include("UserBet.Matches").Where(x => x.UserBet == null).ToList();
                return new List<User>();
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

        public static void ResetStandings()
        {
            using (DataModel model = new DataModel())
            {               
                foreach (var user in model.Users.Include("UserBet.Matches").ToList())
                {
                    if (user.UserBet != null)
                    {
                        user.UserBet.Qualified1Color = "";
                        user.UserBet.Qualified2Color = "";
                        user.UserBet.Qualified3Color = "";
                        user.UserBet.Qualified4Color = "";
                        user.UserBet.Qualified5Color = "";
                        user.UserBet.Qualified6Color = "";
                        user.UserBet.Qualified7Color = "";
                        user.UserBet.Qualified8Color = "";
                        user.UserBet.Qualified9Color = "";
                        user.UserBet.Qualified10Color = "";
                        user.UserBet.Qualified11Color = "";
                        user.UserBet.Qualified12Color = "";
                        user.UserBet.Qualified13Color = "";
                        user.UserBet.Qualified14Color = "";
                        user.UserBet.Qualified15Color = "";
                        user.UserBet.Qualified16Color = "";
                        user.UserBet.QuarterFinalist1Color = "";
                        user.UserBet.QuarterFinalist2Color = "";
                        user.UserBet.QuarterFinalist3Color = "";
                        user.UserBet.QuarterFinalist4Color = "";
                        user.UserBet.QuarterFinalist5Color = "";
                        user.UserBet.QuarterFinalist6Color = "";
                        user.UserBet.QuarterFinalist7Color = "";
                        user.UserBet.QuarterFinalist8Color = "";
                        user.UserBet.Semifinalist1Color = "";
                        user.UserBet.Semifinalist2Color = "";
                        user.UserBet.Semifinalist3Color = "";
                        user.UserBet.Semifinalist4Color = "";
                        user.UserBet.Finalist1Color = "";
                        user.UserBet.Finalist2Color = "";
                        foreach (var u in user.UserBet.Matches)
                        {
                            u.ResultColor = "";
                            u.Status = "SCHEDULED";
                        }
                        user.TotalPoints = 0;
                    }
                }
                model.SaveChanges();
            }
        }

        public static bool DeleteUser(string userName)
        {
            if (userName == null) return false;
            using (DataModel db = new DataModel())
            {
                User user = db.Users.Include("UserBet.Matches").FirstOrDefault(o => o.LoginName == userName);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return true;
                }
                
                return false;
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
                        Qualified1 = bet.Qualified1,
                        Qualified2 = bet.Qualified2,
                        Qualified3 = bet.Qualified3,
                        Qualified4 = bet.Qualified4,
                        Qualified5 = bet.Qualified5,
                        Qualified6 = bet.Qualified6,
                        Qualified7 = bet.Qualified7,
                        Qualified8 = bet.Qualified8,
                        Qualified9 = bet.Qualified9,
                        Qualified10 = bet.Qualified10,
                        Qualified11 = bet.Qualified11,
                        Qualified12 = bet.Qualified12,
                        Qualified13 = bet.Qualified13,
                        Qualified14 = bet.Qualified14,
                        Qualified15 = bet.Qualified15,
                        Qualified16 = bet.Qualified16,
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
            using (DataModel model = new DataModel())
            {
                Result result2 = model.Results.Include("MatchResults").FirstOrDefault(r => r.ResultId == result.ResultId);
                if (result2 != null)
                {
                    foreach (MatchResult newMatch in result.MatchResults)
                    {
                        foreach (var result3 in result2.MatchResults.Where(x => x.MatchResultId == newMatch.MatchResultId))
                        {
                            if (result3.ManuallyUpdated && !manuallyUpdate)
                            {
                                continue;
                            }

                            if (manuallyUpdate && ((result3.AwayScore != newMatch.AwayScore) || (result3.HomeScore != newMatch.HomeScore)))
                            {
                                result3.ManuallyUpdated = true;
                            }
                            result3.AwayScore = newMatch.AwayScore;
                            result3.AwayTeam = newMatch.AwayTeam;
                            result3.HomeScore = newMatch.HomeScore;
                            result3.HomeTeam = newMatch.HomeTeam;
                            result3.Status = newMatch.Status;

                            if (result3.ManuallyUpdated)
                            {
                                result3.Status = "FINISHED";
                            }
                        }
                    }
                    if (manuallyUpdate)
                    {
                        result2.Finalist1 = result.Finalist1;
                        result2.Finalist2 = result.Finalist2;
                        result2.Semifinalist1 = result.Semifinalist1;
                        result2.Semifinalist2 = result.Semifinalist2;
                        result2.Semifinalist3 = result.Semifinalist3;
                        result2.Semifinalist4 = result.Semifinalist4;
                        result2.QuarterFinalist1 = result.QuarterFinalist1;
                        result2.QuarterFinalist2 = result.QuarterFinalist2;
                        result2.QuarterFinalist3 = result.QuarterFinalist3;
                        result2.QuarterFinalist4 = result.QuarterFinalist4;
                        result2.QuarterFinalist5 = result.QuarterFinalist5;
                        result2.QuarterFinalist6 = result.QuarterFinalist6;
                        result2.QuarterFinalist7 = result.QuarterFinalist7;
                        result2.QuarterFinalist8 = result.QuarterFinalist8;
                        result2.Qualified1 = result.Qualified1;
                        result2.Qualified2 = result.Qualified2;
                        result2.Qualified3 = result.Qualified3;
                        result2.Qualified4 = result.Qualified4;
                        result2.Qualified5 = result.Qualified5;
                        result2.Qualified6 = result.Qualified6;
                        result2.Qualified7 = result.Qualified7;
                        result2.Qualified8 = result.Qualified8;
                        result2.Qualified9 = result.Qualified9;
                        result2.Qualified10 = result.Qualified10;
                        result2.Qualified11 = result.Qualified11;
                        result2.Qualified12 = result.Qualified12;
                        result2.Qualified13 = result.Qualified13;
                        result2.Qualified14 = result.Qualified14;
                        result2.Qualified15 = result.Qualified15;
                        result2.Qualified16 = result.Qualified16;
                        result2.TotalGoals = result.TotalGoals;
                    }
                    model.SaveChanges();
                }
                else
                {
                    Result[] entities = new Result[] { result };
                    model.Results.AddOrUpdate<Result>(entities);
                    model.SaveChanges();
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

        public static void SetFinalistsColor(User user, List<string> correctFinalists, List<string> correctSemifinalists, List<string> correctQuarterfinalists, List<string> correctQualified)
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

                foreach (var qualified in correctQualified)
                {
                    if (qualified == selecteduser.UserBet.Qualified1)
                        selecteduser.UserBet.Qualified1Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified2)
                        selecteduser.UserBet.Qualified2Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified3)
                        selecteduser.UserBet.Qualified3Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified4)
                        selecteduser.UserBet.Qualified4Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified5)
                        selecteduser.UserBet.Qualified5Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified6)
                        selecteduser.UserBet.Qualified6Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified7)
                        selecteduser.UserBet.Qualified7Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified8)
                        selecteduser.UserBet.Qualified8Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified9)
                        selecteduser.UserBet.Qualified9Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified10)
                        selecteduser.UserBet.Qualified10Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified11)
                        selecteduser.UserBet.Qualified11Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified12)
                        selecteduser.UserBet.Qualified12Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified13)
                        selecteduser.UserBet.Qualified13Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified14)
                        selecteduser.UserBet.Qualified14Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified15)
                        selecteduser.UserBet.Qualified15Color = "green";
                    if (qualified == selecteduser.UserBet.Qualified16)
                        selecteduser.UserBet.Qualified16Color = "green";
                }

                db.SaveChanges();

            }
        }
    }
}


