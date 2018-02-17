namespace FirstGitProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6001f943-4082-4b2a-abeb-3269641a5b5c', N'Guest1234@msn.com', 0, N'AAQPrj5dvy97l8MrZIlukh4xYzX+KjLZLwexCnXbE4nMZzDcC2IHuGuPALMGGwDw6g==', N'cdd69a7c-db32-4514-97c6-38ac192fa7d8', NULL, 0, 0, NULL, 1, 0, N'Guest1234@msn.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bda665f4-94eb-4881-8aea-b7c981c8b3b3', N'Admin1234@msn.com', 0, N'ACLMG8cUzQ3yOrPvuso+fbk6TSzNgTV8JO9RTqrv3TXjPAghuMraXncZU60JA4qm8A==', N'0f57e1fc-d735-4c90-8f6d-446bfeb2832c', NULL, 0, 0, NULL, 1, 0, N'Admin1234@msn.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'485b5622-3af4-48ad-81ff-8cc48ed28387', N'CanManageHomes')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bda665f4-94eb-4881-8aea-b7c981c8b3b3', N'485b5622-3af4-48ad-81ff-8cc48ed28387')

");
        }
        
        public override void Down()
        {
        }
    }
}
