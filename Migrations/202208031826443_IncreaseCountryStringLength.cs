namespace RésuméBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreaseCountryStringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Countries", "CountryName", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Personals", "CountryName", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personals", "CountryName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Countries", "CountryName", c => c.String(nullable: false, maxLength: 40));
        }
    }
}
