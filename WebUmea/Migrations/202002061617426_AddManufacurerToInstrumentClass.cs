namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManufacurerToInstrumentClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instruments", "InstrumentManufacturer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instruments", "InstrumentManufacturer");
        }
    }
}
