namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedBookNumberAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberAvailable", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Books", "NumberAvailable");
        }
    }
}
