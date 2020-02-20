namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contributions", "PdfId", "dbo.Pdfs");
            DropIndex("dbo.Contributions", new[] { "PdfId" });
            DropColumn("dbo.Contributions", "PdfId");
            DropTable("dbo.Pdfs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pdfs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contributions", "PdfId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contributions", "PdfId");
            AddForeignKey("dbo.Contributions", "PdfId", "dbo.Pdfs", "Id", cascadeDelete: true);
        }
    }
}
