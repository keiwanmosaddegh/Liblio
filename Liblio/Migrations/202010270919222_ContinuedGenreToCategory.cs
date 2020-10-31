namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ContinuedGenreToCategory : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LibraryItems", name: "GenreId", newName: "CategoryId");
            RenameIndex(table: "dbo.LibraryItems", name: "IX_GenreId", newName: "IX_CategoryId");
        }

        public override void Down()
        {
            RenameIndex(table: "dbo.LibraryItems", name: "IX_CategoryId", newName: "IX_GenreId");
            RenameColumn(table: "dbo.LibraryItems", name: "CategoryId", newName: "GenreId");
        }
    }
}
