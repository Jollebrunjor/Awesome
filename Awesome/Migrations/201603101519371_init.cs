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
                        Finalist1 = c.String(),
                        Finalist2 = c.String(),
                        Semifinalist1 = c.String(),
                        Semifinalist2 = c.String(),
                        TopScorer = c.String(),
                    })
                .PrimaryKey(t => t.ResultId);
            
            CreateTable(
                "dbo.MatchResults",
                c => new
                    {
                        MatchResultId = c.Int(nullable: false, identity: true),
                        HomeTeam = c.String(),
                        AwayTeam = c.String(),
                        HomeScore = c.Int(nullable: false),
                        AwayScore = c.Int(nullable: false),
                        Result_ResultId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchResultId)
                .ForeignKey("dbo.Results", t => t.Result_ResultId)
                .Index(t => t.Result_ResultId);
            
            CreateTable(
                "dbo.UserBets",
                c => new
                    {
                        UserBetId = c.Int(nullable: false, identity: true),
                        Finalist1 = c.String(),
                        Finalist2 = c.String(),
                        Semifinalist1 = c.String(),
                        Semifinalist2 = c.String(),
                        TopScorer = c.String(),
                    })
                .PrimaryKey(t => t.UserBetId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        MatchNumber = c.Int(nullable: false),
                        HomeTeam = c.String(),
                        AwayTeam = c.String(),
                        HomeScore = c.Int(nullable: false),
                        AwayScore = c.Int(nullable: false),
                        Result_ResultId = c.Int(),
                        UserBet_UserBetId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Results", t => t.Result_ResultId)
                .ForeignKey("dbo.UserBets", t => t.UserBet_UserBetId)
                .Index(t => t.Result_ResultId)
                .Index(t => t.UserBet_UserBetId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserBet_UserBetId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserBets", t => t.UserBet_UserBetId)
                .Index(t => t.UserBet_UserBetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserBet_UserBetId", "dbo.UserBets");
            DropForeignKey("dbo.Matches", "UserBet_UserBetId", "dbo.UserBets");
            DropForeignKey("dbo.Matches", "Result_ResultId", "dbo.Results");
            DropForeignKey("dbo.MatchResults", "Result_ResultId", "dbo.Results");
            DropIndex("dbo.Users", new[] { "UserBet_UserBetId" });
            DropIndex("dbo.Matches", new[] { "UserBet_UserBetId" });
            DropIndex("dbo.Matches", new[] { "Result_ResultId" });
            DropIndex("dbo.MatchResults", new[] { "Result_ResultId" });
            DropTable("dbo.Users");
            DropTable("dbo.Matches");
            DropTable("dbo.UserBets");
            DropTable("dbo.MatchResults");
            DropTable("dbo.Results");
        }
    }
}
