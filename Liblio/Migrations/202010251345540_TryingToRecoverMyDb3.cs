namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TryingToRecoverMyDb3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            DropColumn("dbo.Books", "GenreId");
            DropColumn("dbo.Books", "Genre_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Books", "Genre_Id", c => c.Int());
            AddColumn("dbo.Books", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
