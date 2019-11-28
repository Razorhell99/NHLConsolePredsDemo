namespace NHLConsolePredsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getridOfTempTableStep1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "GoalScored", c => c.Int());
            AddColumn("dbo.Teams", "GoalAllowed", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "GoalAllowed");
            DropColumn("dbo.Teams", "GoalScored");
        }
    }
}
