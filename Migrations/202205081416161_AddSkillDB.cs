namespace RésuméBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSkillDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillEntryID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        SkillCategory = c.String(maxLength: 35),
                        SkillPoint = c.String(nullable: false, maxLength: 35),
                    })
                .PrimaryKey(t => t.SkillEntryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
        }
    }
}
