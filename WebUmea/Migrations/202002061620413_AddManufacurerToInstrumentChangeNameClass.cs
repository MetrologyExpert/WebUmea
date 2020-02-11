namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManufacurerToInstrumentChangeNameClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instruments", "Manufacturer", c => c.String());
            DropColumn("dbo.Instruments", "InstrumentManufacturer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instruments", "InstrumentManufacturer", c => c.String());
            DropColumn("dbo.Instruments", "Manufacturer");
        }
    }
}
