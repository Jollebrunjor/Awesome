namespace Awesome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        Match1 = c.String(),
                        Match2 = c.String(),
                        Match3 = c.String(),
                    })
                .PrimaryKey(t => t.ResultId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Result_ResultId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Results", t => t.Result_ResultId)
                .Index(t => t.Result_ResultId);
            
            CreateTable(
                "dbo.UserSignUpViews",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Result_ResultId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Results", t => t.Result_ResultId)
                .Index(t => t.Result_ResultId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSignUpViews", "Result_ResultId", "dbo.Results");
            DropForeignKey("dbo.Users", "Result_ResultId", "dbo.Results");
            DropIndex("dbo.UserSignUpViews", new[] { "Result_ResultId" });
            DropIndex("dbo.Users", new[] { "Result_ResultId" });
            DropTable("dbo.UserSignUpViews");
            DropTable("dbo.Users");
            DropTable("dbo.Results");
        }
    }
}
