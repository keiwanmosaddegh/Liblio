namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TryingToRecoverMyDb : DbMigration
    {
        public override void Up()
        {
            Sql(@"
ALTER TABLE Books
DROP COLUMN GenreId
");
        }

        public override void Down()
        {
        }
    }
}
