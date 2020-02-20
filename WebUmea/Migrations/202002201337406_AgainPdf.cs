namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgainPdf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contributions", "PdfId", "dbo.Pdfs");
            DropIndex("dbo.Contributions", new[] { "PdfId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Contributions", "PdfId");
            AddForeignKey("dbo.Contributions", "PdfId", "dbo.Pdfs", "Id", cascadeDelete: true);
        }
    }
}
