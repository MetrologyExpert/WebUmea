namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModels_Uncertainty_Contribution_Pdfs02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contributions",
                c => new
                    {
                        ContributionId = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        Name = c.String(),
                        EstimatedValue = c.Double(nullable: false),
                        PdfId = c.Int(nullable: false),
                        StandardUncertainty = c.Double(nullable: false),
                        SensitivityCoefficient = c.Double(nullable: false),
                        Uncertainty = c.String(),
                        UbId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContributionId)
                .ForeignKey("dbo.UncertaintyBudgets", t => t.UbId, cascadeDelete: true)
                .Index(t => t.UbId);
            
            CreateTable(
                "dbo.Pdfs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Normal = c.Int(nullable: false),
                        Rectangular = c.Int(nullable: false),
                        Trapezoid = c.Int(nullable: false),
                        Triangular = c.Int(nullable: false),
                        Contribution_ContributionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contributions", t => t.Contribution_ContributionId)
                .Index(t => t.Contribution_ContributionId);
            
            CreateTable(
                "dbo.UncertaintyBudgets",
                c => new
                    {
                        UbId = c.Int(nullable: false, identity: true),
                        InstrumentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UbId)
                .ForeignKey("dbo.Instruments", t => t.InstrumentId, cascadeDelete: true)
                .Index(t => t.InstrumentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UncertaintyBudgets", "InstrumentId", "dbo.Instruments");
            DropForeignKey("dbo.Contributions", "UbId", "dbo.UncertaintyBudgets");
            DropForeignKey("dbo.Pdfs", "Contribution_ContributionId", "dbo.Contributions");
            DropIndex("dbo.UncertaintyBudgets", new[] { "InstrumentId" });
            DropIndex("dbo.Pdfs", new[] { "Contribution_ContributionId" });
            DropIndex("dbo.Contributions", new[] { "UbId" });
            DropTable("dbo.UncertaintyBudgets");
            DropTable("dbo.Pdfs");
            DropTable("dbo.Contributions");
        }
    }
}
