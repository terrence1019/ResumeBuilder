namespace RésuméBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobEntryID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        JobID = c.String(maxLength: 35),
                        CompanyName = c.String(maxLength: 60),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.JobEntryID);
            
            CreateTable(
                "dbo.JobDetails",
                c => new
                    {
                        JobDetailEntryID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        JobID = c.String(maxLength: 35),
                        JobFunctionID = c.String(maxLength: 35),
                        JobFunction = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.JobDetailEntryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobDetails");
            DropTable("dbo.Jobs");
        }
    }
}
