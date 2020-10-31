namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveBookGenreId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "GenreId");
        }

        public override void Down()
        {
            AddColumn("dbo.Books", "GenreId", c => c.Byte(nullable: false));
        }
    }
}
