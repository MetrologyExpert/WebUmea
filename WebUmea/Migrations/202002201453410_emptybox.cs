namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emptybox : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contributions", "ProbabilityId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contributions", "ProbabilityId");
        }
    }
}
