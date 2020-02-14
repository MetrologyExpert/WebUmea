namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUncertaintyIdToInstrumentClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instruments", "UncertaintyId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instruments", "UncertaintyId");
        }
    }
}
