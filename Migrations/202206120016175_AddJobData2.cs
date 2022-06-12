namespace RésuméBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobData2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "CompanyName", c => c.String(maxLength: 60));
            AlterColumn("dbo.JobDetails", "JobFunction", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobDetails", "JobFunction", c => c.String(maxLength: 50));
            AlterColumn("dbo.Jobs", "CompanyName", c => c.String(maxLength: 50));
        }
    }
}
