namespace WebUmea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Company]) VALUES (N'c2f9cff2-b4cb-4ab8-bd27-5ba47a9b95df', N'guest@3dscanners.co.uk', 0, N'AJ4Xf3AAm03Bd0Fiz8iNlFyfZZulyftSz6ZUXmzyN5EuEw4qyGD78oOHWqhyOYRszQ==', N'7899d354-849e-4210-8d72-b5a7036229dc', NULL, 0, 0, NULL, 1, 0, N'guest@3dscanners.co.uk', N'New', N'User')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Company]) VALUES (N'9e5e45f7-4819-42d9-99a7-c4cc351bc853', N'benko.peter@gmail.com', 0, N'AKlmDc9EHFYhufBqUG73c1okt2i0rR8m2GWpm8J6Ko3mkUp7IBR+znFuGL6F8oLo/w==', N'f8d132db-23b7-4c6a-b672-6c8cc646370d', NULL, 0, 0, NULL, 1, 0, N'benko.peter@gmail.com', N'Peter Benko', N'Coventry University')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'923b08e2-8258-44f7-b20e-4e4c09bfe6c1', N'Editor')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2f9cff2-b4cb-4ab8-bd27-5ba47a9b95df', N'923b08e2-8258-44f7-b20e-4e4c09bfe6c1')

                    ");
        }
        
        public override void Down()
        {
        }
    }
}
