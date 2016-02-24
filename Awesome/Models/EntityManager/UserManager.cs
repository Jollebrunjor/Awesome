using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using Awesome.Models.DB;
using Awesome.Models.ViewModel;

namespace Awesome.Models.EntityManager
{
    public class UserManager
    {
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
                //user.Result = currentUser.Result;
                
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

        //public bool IsUserInRole(string loginName, string roleName)
        //{
        //    using (DataModel db = new DataModel())
        //    {
        //        User user = db.Users.FirstOrDefault(o => o.LoginName.ToLower().Equals(loginName));
        //        if (user != null)
        //        {
        //            var roles = from q in db.SYSUserRoles
        //                        join r in db.LOOKUPRoles on q.LOOKUPRoleID equals r.LOOKUPRoleID
        //                        where r.RoleName.Equals(roleName) && q.SYSUserID.Equals(SU.SYSUserID)
        //                        select r.RoleName;

        //            if (roles != null)
        //            {
        //                return roles.Any();
        //            }
        //        }

        //        return false;
        //    }
        //}
    }


}