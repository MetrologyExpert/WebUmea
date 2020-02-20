namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNavigationPdfFromContribution : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pdfs", "Contribution_ContributionId", "dbo.Contributions");
            DropIndex("dbo.Pdfs", new[] { "Contribution_ContributionId" });
            DropColumn("dbo.Pdfs", "Contribution_ContributionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pdfs", "Contribution_ContributionId", c => c.Int());
            CreateIndex("dbo.Pdfs", "Contribution_ContributionId");
            AddForeignKey("dbo.Pdfs", "Contribution_ContributionId", "dbo.Contributions", "ContributionId");
        }
    }
}
