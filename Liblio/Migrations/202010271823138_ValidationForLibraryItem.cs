namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ValidationForLibraryItem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LibraryItems", "Author", c => c.String(maxLength: 255));
            AlterColumn("dbo.LibraryItems", "Pages", c => c.Int());
            AlterColumn("dbo.LibraryItems", "RunTimeMinutes", c => c.Int());
            AlterColumn("dbo.LibraryItems", "Type", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.LibraryItems", "Type", c => c.String());
            AlterColumn("dbo.LibraryItems", "RunTimeMinutes", c => c.Int(nullable: false));
            AlterColumn("dbo.LibraryItems", "Pages", c => c.Int(nullable: false));
            AlterColumn("dbo.LibraryItems", "Author", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
