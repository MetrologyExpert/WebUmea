namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContributionChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contributions", "UbId", "dbo.UncertaintyBudgets");
            DropIndex("dbo.Contributions", new[] { "UbId" });
            RenameColumn(table: "dbo.Contributions", name: "UbId", newName: "UncertaintyBudget_UbId");
            AlterColumn("dbo.Contributions", "UncertaintyBudget_UbId", c => c.Int());
            CreateIndex("dbo.Contributions", "UncertaintyBudget_UbId");
            AddForeignKey("dbo.Contributions", "UncertaintyBudget_UbId", "dbo.UncertaintyBudgets", "UbId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contributions", "UncertaintyBudget_UbId", "dbo.UncertaintyBudgets");
            DropIndex("dbo.Contributions", new[] { "UncertaintyBudget_UbId" });
            AlterColumn("dbo.Contributions", "UncertaintyBudget_UbId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Contributions", name: "UncertaintyBudget_UbId", newName: "UbId");
            CreateIndex("dbo.Contributions", "UbId");
            AddForeignKey("dbo.Contributions", "UbId", "dbo.UncertaintyBudgets", "UbId", cascadeDelete: true);
        }
    }
}
