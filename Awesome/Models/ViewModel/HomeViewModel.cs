using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Awesome.Models.DB;
using Awesome.Models.EntityManager;

namespace Awesome.Models.ViewModel
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            ResultTable = GetResultTable();
        }

       public Dictionary<string, int> ResultTable { get; set; }

        public Dictionary<string, int> GetResultTable()
        {
            Dictionary<string, int> resultTable = new Dictionary<string, int>();
            List<User> users = UserManager.GetUsers().Where(x => x.UserBet != null).ToList();

            foreach (var user in users)
            {
                resultTable.Add(user.LoginName, user.TotalPoints);
            }

            return resultTable;
            
        } 
    }
}