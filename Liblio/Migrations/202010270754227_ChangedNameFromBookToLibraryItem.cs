namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangedNameFromBookToLibraryItem : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Books", newName: "LibraryItems");
        }

        public override void Down()
        {
            RenameTable(name: "dbo.LibraryItems", newName: "Books");
        }
    }
}
