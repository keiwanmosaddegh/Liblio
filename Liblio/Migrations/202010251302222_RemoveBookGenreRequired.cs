namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveBookGenreRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            AlterColumn("dbo.Books", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            AlterColumn("dbo.Books", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
