namespace RésuméBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryProperty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.CountryID);
            
            AddColumn("dbo.Personals", "CountryName", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personals", "CountryName");
            DropTable("dbo.Countries");
        }
    }
}
