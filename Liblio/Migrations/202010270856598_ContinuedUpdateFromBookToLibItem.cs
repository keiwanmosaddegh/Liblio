namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ContinuedUpdateFromBookToLibItem : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rentals", name: "Book_Id", newName: "LibraryItem_Id");
            RenameIndex(table: "dbo.Rentals", name: "IX_Book_Id", newName: "IX_LibraryItem_Id");
        }

        public override void Down()
        {
            RenameIndex(table: "dbo.Rentals", name: "IX_LibraryItem_Id", newName: "IX_Book_Id");
            RenameColumn(table: "dbo.Rentals", name: "LibraryItem_Id", newName: "Book_Id");
        }
    }
}
