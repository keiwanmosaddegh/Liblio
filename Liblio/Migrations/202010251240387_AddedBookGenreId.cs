namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedBookGenreId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "GenreId", c => c.Byte(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Books", "GenreId");
        }
    }
}
