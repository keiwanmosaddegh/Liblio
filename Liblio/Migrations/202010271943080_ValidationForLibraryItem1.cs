namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ValidationForLibraryItem1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LibraryItems", "Borrower", c => c.String());
            AlterColumn("dbo.LibraryItems", "BorrowDate", c => c.DateTime());
        }

        public override void Down()
        {
            AlterColumn("dbo.LibraryItems", "BorrowDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LibraryItems", "Borrower", c => c.String(nullable: false));
        }
    }
}
