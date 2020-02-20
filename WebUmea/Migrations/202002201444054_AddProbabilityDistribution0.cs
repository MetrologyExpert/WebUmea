namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProbabilityDistribution0 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contributions", name: "Pdfs_Id", newName: "ProbabilityDistributions_Id");
            RenameIndex(table: "dbo.Contributions", name: "IX_Pdfs_Id", newName: "IX_ProbabilityDistributions_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Contributions", name: "IX_ProbabilityDistributions_Id", newName: "IX_Pdfs_Id");
            RenameColumn(table: "dbo.Contributions", name: "ProbabilityDistributions_Id", newName: "Pdfs_Id");
        }
    }
}
