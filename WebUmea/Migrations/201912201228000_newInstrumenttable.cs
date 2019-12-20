namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newInstrumenttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instruments",
                c => new
                {
                    InstrumentId = c.Int(nullable: false, identity: true),
                    InstrumentName = c.String(),
                    InstrumentModel = c.String(),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.InstrumentId);

         
        }

        public override void Down()
        {
     
        }
    }
}
