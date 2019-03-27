namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'45d39e97-c209-4f64-bcb3-1ed1cea23079', N'admin@vidly.com', 0, N'APvFctLl6fXBS5Q9yDObdQuHCC2H2KwxAYU9Z59InfY9h0GcavdKZYna5gjfWJyvww==', N'68e09c00-86ed-4ab2-bf53-7414944230e0', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4cfcd45b-b53c-4e02-b58d-e1947f654f35', N'guest@vidly.com', 0, N'ACaTY085RopZme4/lA7HNO6mWvdUTqwQWgouvEzLsReBPg0oFAXsT6lOWQvO7+aVkw==', N'd22356a3-8fd3-4f15-b0d1-1d768e1d8b31', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e1311543-d658-41af-8472-8a13d72f66c4', N'CanManageMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'45d39e97-c209-4f64-bcb3-1ed1cea23079', N'e1311543-d658-41af-8472-8a13d72f66c4')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
