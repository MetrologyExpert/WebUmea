namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserProfileTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserProfiles");
        }
        
        public override void Down()
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
    }
}
