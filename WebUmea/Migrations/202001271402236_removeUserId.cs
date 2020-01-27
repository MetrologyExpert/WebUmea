namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUserId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "IdUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IdUser", c => c.Int(nullable: false));
        }
    }
}
