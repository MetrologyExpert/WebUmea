namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IDUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                    })
                .PrimaryKey(t => t.IDUser);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
