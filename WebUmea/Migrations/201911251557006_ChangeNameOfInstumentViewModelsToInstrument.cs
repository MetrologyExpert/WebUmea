namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameOfInstumentViewModelsToInstrument : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InstrumentViewModels", newName: "Instruments");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Instruments", newName: "InstrumentViewModels");
        }
    }
}
