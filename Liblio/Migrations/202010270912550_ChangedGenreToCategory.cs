namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangedGenreToCategory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Genres", newName: "Categories");
        }

        public override void Down()
        {
            RenameTable(name: "dbo.Categories", newName: "Genres");
        }
    }
}
