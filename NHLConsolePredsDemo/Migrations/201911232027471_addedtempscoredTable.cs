namespace NHLConsolePredsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtempscoredTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TempScoreTables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SearchedTeamID = c.Int(nullable: false),
                        GoalScored = c.Int(nullable: false),
                        GoalAllowed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TempScoreTables");
        }
    }
}
