namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdatedBook1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ReleaseDate = c.DateTime(nullable: false),
                    DateAdded = c.DateTime(nullable: false),
                    NumberInStock = c.Int(nullable: false),
                    Genre_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Genre_Id);

            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
        }
    }
}
