namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompleteModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contributions", "UncertaintyBudget_UbId", "dbo.UncertaintyBudgets");
            DropIndex("dbo.Contributions", new[] { "UncertaintyBudget_UbId" });
            RenameColumn(table: "dbo.Contributions", name: "UncertaintyBudget_UbId", newName: "UbId");
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.UncertaintyBudgets", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.UncertaintyBudgets", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contributions", "UbId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contributions", "UbId");
            CreateIndex("dbo.UncertaintyBudgets", "AuthorId");
            CreateIndex("dbo.UncertaintyBudgets", "UserId");
            AddForeignKey("dbo.UncertaintyBudgets", "AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
            AddForeignKey("dbo.UncertaintyBudgets", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Contributions", "UbId", "dbo.UncertaintyBudgets", "UbId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contributions", "UbId", "dbo.UncertaintyBudgets");
            DropForeignKey("dbo.UncertaintyBudgets", "UserId", "dbo.Users");
            DropForeignKey("dbo.UncertaintyBudgets", "AuthorId", "dbo.Authors");
            DropIndex("dbo.UncertaintyBudgets", new[] { "UserId" });
            DropIndex("dbo.UncertaintyBudgets", new[] { "AuthorId" });
            DropIndex("dbo.Contributions", new[] { "UbId" });
            AlterColumn("dbo.Contributions", "UbId", c => c.Int());
            DropColumn("dbo.UncertaintyBudgets", "UserId");
            DropColumn("dbo.UncertaintyBudgets", "AuthorId");
            DropTable("dbo.Users");
            DropTable("dbo.Authors");
            RenameColumn(table: "dbo.Contributions", name: "UbId", newName: "UncertaintyBudget_UbId");
            CreateIndex("dbo.Contributions", "UncertaintyBudget_UbId");
            AddForeignKey("dbo.Contributions", "UncertaintyBudget_UbId", "dbo.UncertaintyBudgets", "UbId");
        }
    }
}
