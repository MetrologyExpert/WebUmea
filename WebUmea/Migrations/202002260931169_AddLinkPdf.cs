namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLinkPdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contributions", "Pdfs_IdNumber", c => c.Int());
            CreateIndex("dbo.Contributions", "Pdfs_IdNumber");
            AddForeignKey("dbo.Contributions", "Pdfs_IdNumber", "dbo.Pdfs", "IdNumber");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contributions", "Pdfs_IdNumber", "dbo.Pdfs");
            DropIndex("dbo.Contributions", new[] { "Pdfs_IdNumber" });
            DropColumn("dbo.Contributions", "Pdfs_IdNumber");
        }
    }
}
