namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8cc030d2-4a4d-42a5-adff-a978241e6072', N'admin@libmgt.com', 0, N'AL6QkyLO3ws4vneJKpoR2zCUra7lGQFwN8JyIuFgd9UPBtAgg3h3ri9Ltk0O9XBPsQ==', N'bd84fe09-f87f-415e-9e62-b0b337ffb150', NULL, 0, 0, NULL, 1, 0, N'admin@libmgt.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e29dc3f5-b096-42ec-baf9-44c293671033', N'guest@libmgt.com', 0, N'AM7ZXzwT2j6I4bRroVS6+eiEF5m8BMeqVYkKOppClwEefMpZXdK0F0RKF425nEYgnQ==', N'766b85f2-fe25-4dd3-ac54-46735e7bf279', NULL, 0, 0, NULL, 1, 0, N'guest@libmgt.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8bf153cd-a303-42b0-a91e-dc22f9a0464f', N'CanManageBooks')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8cc030d2-4a4d-42a5-adff-a978241e6072', N'8bf153cd-a303-42b0-a91e-dc22f9a0464f')
");
        }

        public override void Down()
        {
        }
    }
}
