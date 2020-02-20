namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProbabilityDistribution1 : DbMigration
    {
        public override void Up()
        {
 
            DropIndex("dbo.Contributions", new[] { "ProbabilityDistributions_Id" });
            DropColumn("dbo.Contributions", "ProbabilityId");
        
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Contributions", "ProbabilityDistributions_Id", c => c.Int());
            AddColumn("dbo.Contributions", "ProbabilityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contributions", "ProbabilityDistributions_Id");
            AddForeignKey("dbo.Contributions", "ProbabilityDistributions_Id", "dbo.ProbabilityDistributions", "Id");
        }
    }
}
