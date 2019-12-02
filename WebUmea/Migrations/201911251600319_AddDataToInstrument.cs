namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToInstrument : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Instruments ON");
            Sql("INSERT INTO Instruments(InstrumentId,InstrumentName,InstrumentModel,Description) VALUES (1,'Vernier Caliper','Mitutoyo AF-160','Best caliper ')");
            Sql("INSERT INTO Instruments(InstrumentId,InstrumentName,InstrumentModel,Description) VALUES (2,'Micrometer','Mitutoyo 25','The micrometer')");
            Sql("INSERT INTO Instruments(InstrumentId,InstrumentName,InstrumentModel,Description) VALUES (3,'Bore Gage','Mitutoyo BG 12.5 - 25 mm','Bore gage to measure hole ')");

        }

        public override void Down()
        {
        }
    }
}
