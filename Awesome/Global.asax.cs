using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Data.Entity;
using System.Web.Caching;
using Awesome.Models;
using Awesome.Models.DB;

namespace Awesome
{
    public class MvcApplication : System.Web.HttpApplication
    {

        static void ScheduleTaskTrigger()
        {
            HttpRuntime.Cache.Add("ScheduledTaskTrigger",
                                  string.Empty,
                                  null,
                                  Cache.NoAbsoluteExpiration,
                                  TimeSpan.FromMinutes(10), // Every 1 hour
                                  CacheItemPriority.NotRemovable,
                                  new CacheItemRemovedCallback(PerformScheduledTasks));
        }

        static void PerformScheduledTasks(string key, Object value, CacheItemRemovedReason reason)
        {
            

            ScheduledTasks.AutomaticUpdateResults();
            ScheduledTasks.AddPointsToAllUsers();
            ScheduleTaskTrigger();
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ScheduleTaskTrigger();

            Database.SetInitializer<DataModel>(new DropCreateDatabaseIfModelChanges<DataModel>());
        }
    }
}
