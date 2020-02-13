namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0d97a4d9-9c6f-45b0-abb5-763cea67136c', N'tigran1205@gmail.com', 0, N'AH+CMhf3JRAi9UdJrK2cFoeMoccxXjo+Ihz/7TJKlvf5At3M6G2L3yoXcsrtU1KnqQ==', N'15a98f14-547d-47c3-bf6e-9eaa5ff6eb63', NULL, 0, 0, NULL, 1, 0, N'tigran1205@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'847151ac-99d4-4ef9-bc1c-4c1b164b2a08', N'admin@tigran.com', 0, N'AHR1V+5ZswRiChULhUiYV2FqMr8Ic7YJN/K6XiJsXMbSAl1VaVy805uRq5nd5gQhQw==', N'64f78a1d-3a82-4fe9-8c75-0c7a80825b38', NULL, 0, 0, NULL, 1, 0, N'admin@tigran.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5c2e3b33-6965-4dcc-bab6-1ab4aae7cb43', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'847151ac-99d4-4ef9-bc1c-4c1b164b2a08', N'5c2e3b33-6965-4dcc-bab6-1ab4aae7cb43')


");
        }
        
        public override void Down()
        {
        }
    }
}
