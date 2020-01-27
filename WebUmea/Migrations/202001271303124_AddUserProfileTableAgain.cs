namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProfileTableAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
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
            DropTable("dbo.UserProfiles");
        }
    }
}
