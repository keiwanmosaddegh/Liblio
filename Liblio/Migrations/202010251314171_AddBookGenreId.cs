namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddBookGenreId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            AddColumn("dbo.Books", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Books", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            AlterColumn("dbo.Books", "Genre_Id", c => c.Int());
            DropColumn("dbo.Books", "GenreId");
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
