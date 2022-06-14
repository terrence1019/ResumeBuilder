namespace RésuméBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFieldLimits : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobDetails", "JobID", c => c.String(maxLength: 40));
            AlterColumn("dbo.JobDetails", "JobFunctionID", c => c.String(maxLength: 40));
            AlterColumn("dbo.JobDetails", "JobFunction", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobDetails", "JobFunction", c => c.String(maxLength: 150));
            AlterColumn("dbo.JobDetails", "JobFunctionID", c => c.String(maxLength: 35));
            AlterColumn("dbo.JobDetails", "JobID", c => c.String(maxLength: 35));
        }
    }
}
