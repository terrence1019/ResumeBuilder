namespace RésuméBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPosition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Position", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Position");
        }
    }
}
