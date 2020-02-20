namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BindPdfToContributionC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pdfs", "Coeff", c => c.Int(nullable: false));
   
        }
        
        public override void Down()
        {
         
        }
    }
}
