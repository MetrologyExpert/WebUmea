namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProbabilityDistribution2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contributions", "ProbabilityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contributions", "ProbabilityId", c => c.Int(nullable: false));
        }
    }
}
