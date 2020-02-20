namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newpdfs3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contributions", "pdfId", c => c.Int(nullable: false));
      

        }
        
        public override void Down()
        {
            DropColumn("dbo.Contributions", "pdfId");
        }
    }
}
