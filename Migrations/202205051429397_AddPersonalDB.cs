namespace RésuméBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonalDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        PersonalEntryID = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        StreetLocation = c.String(nullable: false, maxLength: 40),
                        AreaLocation = c.String(nullable: false, maxLength: 40),
                        RegionLocation = c.String(nullable: false, maxLength: 40),
                        PhoneMobile = c.String(nullable: false, maxLength: 14),
                        PhoneHome = c.String(maxLength: 14),
                        PhoneWork = c.String(maxLength: 14),
                        EmailHome = c.String(nullable: false, maxLength: 30),
                        EmailWork = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.PersonalEntryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personals");
        }
    }
}
