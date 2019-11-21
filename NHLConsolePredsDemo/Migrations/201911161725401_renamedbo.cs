namespace NHLConsolePredsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedbo : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Games", newName: "Games");
        }

        public override void Down()
        {
            RenameTable(name: "dbo.Games", newName: "dbo.Games");
        }
    }
}

