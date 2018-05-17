namespace Awesome.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "Qualified1", c => c.String());
            AddColumn("dbo.Results", "Qualified2", c => c.String());
            AddColumn("dbo.Results", "Qualified3", c => c.String());
            AddColumn("dbo.Results", "Qualified4", c => c.String());
            AddColumn("dbo.Results", "Qualified5", c => c.String());
            AddColumn("dbo.Results", "Qualified6", c => c.String());
            AddColumn("dbo.Results", "Qualified7", c => c.String());
            AddColumn("dbo.Results", "Qualified8", c => c.String());
            AddColumn("dbo.Results", "Qualified9", c => c.String());
            AddColumn("dbo.Results", "Qualified10", c => c.String());
            AddColumn("dbo.Results", "Qualified11", c => c.String());
            AddColumn("dbo.Results", "Qualified12", c => c.String());
            AddColumn("dbo.Results", "Qualified13", c => c.String());
            AddColumn("dbo.Results", "Qualified14", c => c.String());
            AddColumn("dbo.Results", "Qualified15", c => c.String());
            AddColumn("dbo.Results", "Qualified16", c => c.String());
            AddColumn("dbo.UserBets", "Qualified1", c => c.String());
            AddColumn("dbo.UserBets", "Qualified2", c => c.String());
            AddColumn("dbo.UserBets", "Qualified3", c => c.String());
            AddColumn("dbo.UserBets", "Qualified4", c => c.String());
            AddColumn("dbo.UserBets", "Qualified5", c => c.String());
            AddColumn("dbo.UserBets", "Qualified6", c => c.String());
            AddColumn("dbo.UserBets", "Qualified7", c => c.String());
            AddColumn("dbo.UserBets", "Qualified8", c => c.String());
            AddColumn("dbo.UserBets", "Qualified9", c => c.String());
            AddColumn("dbo.UserBets", "Qualified10", c => c.String());
            AddColumn("dbo.UserBets", "Qualified11", c => c.String());
            AddColumn("dbo.UserBets", "Qualified12", c => c.String());
            AddColumn("dbo.UserBets", "Qualified13", c => c.String());
            AddColumn("dbo.UserBets", "Qualified14", c => c.String());
            AddColumn("dbo.UserBets", "Qualified15", c => c.String());
            AddColumn("dbo.UserBets", "Qualified16", c => c.String());
            AddColumn("dbo.UserBets", "Qualified1Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified2Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified3Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified4Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified5Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified6Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified7Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified8Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified9Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified10Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified11Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified12Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified13Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified14Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified15Color", c => c.String());
            AddColumn("dbo.UserBets", "Qualified16Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBets", "Qualified16Color");
            DropColumn("dbo.UserBets", "Qualified15Color");
            DropColumn("dbo.UserBets", "Qualified14Color");
            DropColumn("dbo.UserBets", "Qualified13Color");
            DropColumn("dbo.UserBets", "Qualified12Color");
            DropColumn("dbo.UserBets", "Qualified11Color");
            DropColumn("dbo.UserBets", "Qualified10Color");
            DropColumn("dbo.UserBets", "Qualified9Color");
            DropColumn("dbo.UserBets", "Qualified8Color");
            DropColumn("dbo.UserBets", "Qualified7Color");
            DropColumn("dbo.UserBets", "Qualified6Color");
            DropColumn("dbo.UserBets", "Qualified5Color");
            DropColumn("dbo.UserBets", "Qualified4Color");
            DropColumn("dbo.UserBets", "Qualified3Color");
            DropColumn("dbo.UserBets", "Qualified2Color");
            DropColumn("dbo.UserBets", "Qualified1Color");
            DropColumn("dbo.UserBets", "Qualified16");
            DropColumn("dbo.UserBets", "Qualified15");
            DropColumn("dbo.UserBets", "Qualified14");
            DropColumn("dbo.UserBets", "Qualified13");
            DropColumn("dbo.UserBets", "Qualified12");
            DropColumn("dbo.UserBets", "Qualified11");
            DropColumn("dbo.UserBets", "Qualified10");
            DropColumn("dbo.UserBets", "Qualified9");
            DropColumn("dbo.UserBets", "Qualified8");
            DropColumn("dbo.UserBets", "Qualified7");
            DropColumn("dbo.UserBets", "Qualified6");
            DropColumn("dbo.UserBets", "Qualified5");
            DropColumn("dbo.UserBets", "Qualified4");
            DropColumn("dbo.UserBets", "Qualified3");
            DropColumn("dbo.UserBets", "Qualified2");
            DropColumn("dbo.UserBets", "Qualified1");
            DropColumn("dbo.Results", "Qualified16");
            DropColumn("dbo.Results", "Qualified15");
            DropColumn("dbo.Results", "Qualified14");
            DropColumn("dbo.Results", "Qualified13");
            DropColumn("dbo.Results", "Qualified12");
            DropColumn("dbo.Results", "Qualified11");
            DropColumn("dbo.Results", "Qualified10");
            DropColumn("dbo.Results", "Qualified9");
            DropColumn("dbo.Results", "Qualified8");
            DropColumn("dbo.Results", "Qualified7");
            DropColumn("dbo.Results", "Qualified6");
            DropColumn("dbo.Results", "Qualified5");
            DropColumn("dbo.Results", "Qualified4");
            DropColumn("dbo.Results", "Qualified3");
            DropColumn("dbo.Results", "Qualified2");
            DropColumn("dbo.Results", "Qualified1");
        }
    }
}
