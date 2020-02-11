namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePdFModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pdfs", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Pdfs", "Normal");
            DropColumn("dbo.Pdfs", "Rectangular");
            DropColumn("dbo.Pdfs", "Trapezoid");
            DropColumn("dbo.Pdfs", "Triangular");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pdfs", "Triangular", c => c.Int(nullable: false));
            AddColumn("dbo.Pdfs", "Trapezoid", c => c.Int(nullable: false));
            AddColumn("dbo.Pdfs", "Rectangular", c => c.Int(nullable: false));
            AddColumn("dbo.Pdfs", "Normal", c => c.Int(nullable: false));
            DropColumn("dbo.Pdfs", "Name");
        }
    }
}
