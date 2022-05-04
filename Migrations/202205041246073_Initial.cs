namespace RésuméBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false, identity: true),
                        ApplicantUsername = c.String(nullable: false, maxLength: 77),
                    })
                .PrimaryKey(t => t.ApplicantID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Applicants");
        }
    }
}
