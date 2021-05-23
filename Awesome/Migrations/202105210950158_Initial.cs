namespace Awesome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        Finalist1 = c.String(),
                        Finalist2 = c.String(),
                        Semifinalist1 = c.String(),
                        Semifinalist2 = c.String(),
                        Semifinalist3 = c.String(),
                        Semifinalist4 = c.String(),
                        QuarterFinalist1 = c.String(),
                        QuarterFinalist2 = c.String(),
                        QuarterFinalist3 = c.String(),
                        QuarterFinalist4 = c.String(),
                        QuarterFinalist5 = c.String(),
                        QuarterFinalist6 = c.String(),
                        QuarterFinalist7 = c.String(),
                        QuarterFinalist8 = c.String(),
                        Qualified1 = c.String(),
                        Qualified2 = c.String(),
                        Qualified3 = c.String(),
                        Qualified4 = c.String(),
                        Qualified5 = c.String(),
                        Qualified6 = c.String(),
                        Qualified7 = c.String(),
                        Qualified8 = c.String(),
                        Qualified9 = c.String(),
                        Qualified10 = c.String(),
                        Qualified11 = c.String(),
                        Qualified12 = c.String(),
                        Qualified13 = c.String(),
                        Qualified14 = c.String(),
                        Qualified15 = c.String(),
                        Qualified16 = c.String(),
                        TopScorer = c.String(),
                        TotalGoals = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId);
            
            CreateTable(
                "dbo.MatchResults",
                c => new
                    {
                        MatchResultId = c.Int(nullable: false, identity: true),
                        HomeTeam = c.String(),
                        AwayTeam = c.String(),
                        HomeScore = c.Int(nullable: true),
                        AwayScore = c.Int(nullable: true),
                        Status = c.String(),
                        ManuallyUpdated = c.Boolean(nullable: false),
                        Result_ResultId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchResultId)
                .ForeignKey("dbo.Results", t => t.Result_ResultId)
                .Index(t => t.Result_ResultId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Rolename = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        TotalPoints = c.Int(nullable: false),
                        UserBet_UserBetId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserBets", t => t.UserBet_UserBetId)
                .Index(t => t.UserBet_UserBetId);
            
            CreateTable(
                "dbo.UserBets",
                c => new
                    {
                        UserBetId = c.Int(nullable: false, identity: true),
                        Finalist1 = c.String(),
                        Finalist2 = c.String(),
                        Semifinalist1 = c.String(),
                        Semifinalist2 = c.String(),
                        Semifinalist3 = c.String(),
                        Semifinalist4 = c.String(),
                        QuarterFinalist1 = c.String(),
                        QuarterFinalist2 = c.String(),
                        QuarterFinalist3 = c.String(),
                        QuarterFinalist4 = c.String(),
                        QuarterFinalist5 = c.String(),
                        QuarterFinalist6 = c.String(),
                        QuarterFinalist7 = c.String(),
                        QuarterFinalist8 = c.String(),
                        Qualified1 = c.String(),
                        Qualified2 = c.String(),
                        Qualified3 = c.String(),
                        Qualified4 = c.String(),
                        Qualified5 = c.String(),
                        Qualified6 = c.String(),
                        Qualified7 = c.String(),
                        Qualified8 = c.String(),
                        Qualified9 = c.String(),
                        Qualified10 = c.String(),
                        Qualified11 = c.String(),
                        Qualified12 = c.String(),
                        Qualified13 = c.String(),
                        Qualified14 = c.String(),
                        Qualified15 = c.String(),
                        Qualified16 = c.String(),
                        TopScorer = c.String(),
                        TotalGoals = c.Int(nullable: false),
                        Finalist1Color = c.String(),
                        Finalist2Color = c.String(),
                        Semifinalist1Color = c.String(),
                        Semifinalist2Color = c.String(),
                        Semifinalist3Color = c.String(),
                        Semifinalist4Color = c.String(),
                        QuarterFinalist1Color = c.String(),
                        QuarterFinalist2Color = c.String(),
                        QuarterFinalist3Color = c.String(),
                        QuarterFinalist4Color = c.String(),
                        QuarterFinalist5Color = c.String(),
                        QuarterFinalist6Color = c.String(),
                        QuarterFinalist7Color = c.String(),
                        QuarterFinalist8Color = c.String(),
                        Qualified1Color = c.String(),
                        Qualified2Color = c.String(),
                        Qualified3Color = c.String(),
                        Qualified4Color = c.String(),
                        Qualified5Color = c.String(),
                        Qualified6Color = c.String(),
                        Qualified7Color = c.String(),
                        Qualified8Color = c.String(),
                        Qualified9Color = c.String(),
                        Qualified10Color = c.String(),
                        Qualified11Color = c.String(),
                        Qualified12Color = c.String(),
                        Qualified13Color = c.String(),
                        Qualified14Color = c.String(),
                        Qualified15Color = c.String(),
                        Qualified16Color = c.String(),
                    })
                .PrimaryKey(t => t.UserBetId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        ResultColor = c.String(),
                        HomeTeam = c.String(),
                        AwayTeam = c.String(),
                        HomeScore = c.Int(nullable: false),
                        AwayScore = c.Int(nullable: false),
                        Status = c.String(),
                        Matchday = c.Int(nullable: false),
                        Date = c.String(),
                        UserBet_UserBetId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.UserBets", t => t.UserBet_UserBetId)
                .Index(t => t.UserBet_UserBetId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Role_RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Role_RoleId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Role_RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserBet_UserBetId", "dbo.UserBets");
            DropForeignKey("dbo.Matches", "UserBet_UserBetId", "dbo.UserBets");
            DropForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.MatchResults", "Result_ResultId", "dbo.Results");
            DropIndex("dbo.UserRoles", new[] { "Role_RoleId" });
            DropIndex("dbo.UserRoles", new[] { "User_UserId" });
            DropIndex("dbo.Matches", new[] { "UserBet_UserBetId" });
            DropIndex("dbo.Users", new[] { "UserBet_UserBetId" });
            DropIndex("dbo.MatchResults", new[] { "Result_ResultId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Matches");
            DropTable("dbo.UserBets");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.MatchResults");
            DropTable("dbo.Results");
        }
    }
}
