namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'30acfb85-635e-4d0c-8856-0dbfa9c2f35b', N'guest@vidly.com', 0, N'AExR2h8xjZo4bF0S0Fo5EnnhEGryMu72CFmhP8lmVc57g0BfpAPCqLC8mu6EuPtnpA==', N'a7709580-87c3-4af4-8c32-b33bf368e503', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                  INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'79026784-4411-4f24-af2d-dc59f0540205', N'admin@vidly.com', 0, N'AEzzQnlM/pNdxS0P5Nn5AOYh14uilkQNSGzK4bqRmP4ah32tyh/4alsbHB7LUsuugA==', N'b127aa58-16b4-4ae1-82e3-939d64004781', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')"
                );
            Sql(@"
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'aa057f4d-6f75-4d5a-aadf-00ebccef41be', N'CanManageMovies')"           
                );
            Sql(@"
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'79026784-4411-4f24-af2d-dc59f0540205', N'aa057f4d-6f75-4d5a-aadf-00ebccef41be')"
                );
        }

        public override void Down()
        {
        }
    }
}
