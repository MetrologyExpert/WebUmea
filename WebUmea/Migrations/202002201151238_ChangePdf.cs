namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePdf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pdfs", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pdfs", "Name", c => c.Int(nullable: false));
        }
    }
}
