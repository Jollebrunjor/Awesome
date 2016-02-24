using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Web.DynamicData;
using System.Web.UI;
using Awesome.Models.ViewModel;

namespace Awesome.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataModel : DbContext
    {
        static DataModel()
        {
            Database.SetInitializer<DataModel>(null);
        }
        // Your context has been configured to use a 'DataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Awesome.Models.DB.DataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataModel' 
        // connection string in the application configuration file.
        //public DataModel()
        //    : base("name=DataModel")
        //{
        //}

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public System.Data.Entity.DbSet<Awesome.Models.ViewModel.UserSignUpView> UserSignUpViews { get; set; }
    }

    public class User 
    {

        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Result Result { get; set; }
     
    }

    public class Result
    {
        public Result()
        {
            Users = new List<User>();
        }
        public int ResultId { get; set; }
        public string Match1 { get; set; }
        public string Match2 { get; set; }
        public string Match3 { get; set; }

        public ICollection<User> Users { get; set; }
    }

}