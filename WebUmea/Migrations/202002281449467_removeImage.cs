namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeImage : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ImageGalleries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageGalleries",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
