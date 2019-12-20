namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
          Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b3e061b8-d43a-4145-8fbf-76096de84a98', N'guest@3dscanners.co.uk', 0, N'ANHv8jqiHnshp2SYlSvsnb7nSvBQ9EvxCCj8NCOfyA9A8ZijhQ1+4LWbHYq4aJ+Dww==', N'6f55f97f-d910-4bf8-8d97-58ed03b23468', NULL, 0, 0, NULL, 1, 0, N'guest@3dscanners.co.uk')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9e5e45f7-4819-42d9-99a7-c4cc351bc853', N'benko.peter@gmail.com', 0, N'AKlmDc9EHFYhufBqUG73c1okt2i0rR8m2GWpm8J6Ko3mkUp7IBR+znFuGL6F8oLo/w==', N'f8d132db-23b7-4c6a-b672-6c8cc646370d', NULL, 0, 0, NULL, 1, 0, N'benko.peter@gmail.com')
              
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6bc0cbdd-4e1c-4be6-b3c4-e09e763a3e54', N'CanManageInstruments')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b3e061b8-d43a-4145-8fbf-76096de84a98', N'6bc0cbdd-4e1c-4be6-b3c4-e09e763a3e54')


                ");

        }

    public override void Down()
        {
        }
    }
}
