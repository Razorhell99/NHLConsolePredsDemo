namespace NHLConsolePredsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetoDB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Match", newName: "Games");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Games", newName: "Match");
        }
    }
}
