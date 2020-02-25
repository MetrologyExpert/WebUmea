namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUncertaintyBudget : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UncertaintyBudgets",
                c => new
                    {
                        UbId = c.Int(nullable: false, identity: true),
                        InstrumentId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UbId);
            
            CreateIndex("dbo.Contributions", "UbId");
            AddForeignKey("dbo.Contributions", "UbId", "dbo.UncertaintyBudgets", "UbId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contributions", "UbId", "dbo.UncertaintyBudgets");
            DropIndex("dbo.Contributions", new[] { "UbId" });
            DropTable("dbo.UncertaintyBudgets");
        }
    }
}
