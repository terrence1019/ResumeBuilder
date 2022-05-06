namespace RésuméBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_Column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personals", "ApplicantID", c => c.Int(nullable: false));
            DropColumn("dbo.Personals", "ApplicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personals", "ApplicationId", c => c.Int(nullable: false));
            DropColumn("dbo.Personals", "ApplicantId");
        }
    }
}
