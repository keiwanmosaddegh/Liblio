namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RefactoredLibraryItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LibraryItems", "Title", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.LibraryItems", "Author", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.LibraryItems", "Pages", c => c.Int(nullable: false));
            AddColumn("dbo.LibraryItems", "RunTimeMinutes", c => c.Int(nullable: false));
            AddColumn("dbo.LibraryItems", "IsBorrowable", c => c.Boolean(nullable: false));
            AddColumn("dbo.LibraryItems", "Borrower", c => c.String(nullable: false));
            AddColumn("dbo.LibraryItems", "BorrowDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.LibraryItems", "Type", c => c.String());
            DropColumn("dbo.LibraryItems", "Name");
            DropColumn("dbo.LibraryItems", "ReleaseDate");
            DropColumn("dbo.LibraryItems", "DateAdded");
            DropColumn("dbo.LibraryItems", "NumberInStock");
            DropColumn("dbo.LibraryItems", "NumberAvailable");
        }

        public override void Down()
        {
            AddColumn("dbo.LibraryItems", "NumberAvailable", c => c.Int(nullable: false));
            AddColumn("dbo.LibraryItems", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.LibraryItems", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.LibraryItems", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.LibraryItems", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.LibraryItems", "Type");
            DropColumn("dbo.LibraryItems", "BorrowDate");
            DropColumn("dbo.LibraryItems", "Borrower");
            DropColumn("dbo.LibraryItems", "IsBorrowable");
            DropColumn("dbo.LibraryItems", "RunTimeMinutes");
            DropColumn("dbo.LibraryItems", "Pages");
            DropColumn("dbo.LibraryItems", "Author");
            DropColumn("dbo.LibraryItems", "Title");
        }
    }
}
