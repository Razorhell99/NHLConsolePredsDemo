namespace NHLConsolePredsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullvalues : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TempScoreTables", "GoalScored", c => c.Int());
            AlterColumn("dbo.TempScoreTables", "GoalAllowed", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TempScoreTables", "GoalAllowed", c => c.Int(nullable: false));
            AlterColumn("dbo.TempScoreTables", "GoalScored", c => c.Int(nullable: false));
        }
    }
}
