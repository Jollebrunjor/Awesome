using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Security;
using Awesome.Models.DB;
using Awesome.Models.ViewModel;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Awesome.Models.EntityManager
{
    public class UserManager
    {

        public static bool HasBetted(string userName)
        {
            using (DataModel db = new DataModel())
            {

               User user = db.Users.Include("UserBet.Matches").FirstOrDefault(o => o.LoginName == userName);

                if(user?.UserBet == null)
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

                if(user != null)
                user.UserBet = new UserBet()
                {
                    Finalist1 = bet.Finalist1,
                    Finalist2 = bet.Finalist2,
                    Semifinalist1 = bet.Semifinalist1,
                    Semifinalist2 = bet.Semifinalist2,
                    TopScorer = bet.TopScorer,
                    Matches = bet.Matches
                };
                db.Users.AddOrUpdate(user);
                db.SaveChanges();


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

    }


}