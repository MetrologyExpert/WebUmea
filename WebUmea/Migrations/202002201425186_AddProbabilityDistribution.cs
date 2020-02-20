namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProbabilityDistribution : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProbabilityDistributions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Coefficient = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contributions", "ProbabilityId", c => c.Int(nullable: false));
            AddColumn("dbo.Contributions", "Pdfs_Id", c => c.Int());
            CreateIndex("dbo.Contributions", "Pdfs_Id");
            AddForeignKey("dbo.Contributions", "Pdfs_Id", "dbo.ProbabilityDistributions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contributions", "Pdfs_Id", "dbo.ProbabilityDistributions");
            DropIndex("dbo.Contributions", new[] { "Pdfs_Id" });
            DropColumn("dbo.Contributions", "Pdfs_Id");
            DropColumn("dbo.Contributions", "ProbabilityId");
            DropTable("dbo.ProbabilityDistributions");
        }
    }
}
