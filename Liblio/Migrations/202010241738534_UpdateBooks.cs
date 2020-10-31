namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateBooks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Books", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            AlterColumn("dbo.Books", "Genre_Id", c => c.Int());
            AlterColumn("dbo.Books", "Name", c => c.String());
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
