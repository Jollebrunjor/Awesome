using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Awesome.Models.DB;
using Awesome.Models.EntityManager;

namespace Awesome.Models.ViewModel
{
    public class MyBetPageViewModel
    {
        public MyBetPageViewModel()
        {
            CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
            CurrentUserBet = GetBetForUser(CurrentUser);
            OtherUsersBet = GetOtherUsersBet();
            
        }
        
        public List<User> OtherUsersBet { get; set; } 
        public string CurrentUser { get; set; }
        public UserBet CurrentUserBet { get; set; }

        public UserBet GetBetForUser(string user)
        {
            return UserManager.GetBet(user);         
        }

        public List<User> GetOtherUsersBet()
        {
            return UserManager.GetUsers().Where(x => x.LoginName != CurrentUser).ToList();
        }
    }
}