namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TryingToRecoverMyDb2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Books", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            DropColumn("dbo.Books", "Genre_Id");
            DropColumn("dbo.Books", "GenreId");
        }
    }
}
