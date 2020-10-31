namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveBookGenreId1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
ALTER TABLE Books
DROP COLUMN Genre_Id
");
        }

        public override void Down()
        {
        }
    }
}
