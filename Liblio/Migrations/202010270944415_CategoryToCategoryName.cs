namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CategoryToCategoryName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Categories", "Name");
        }

        public override void Down()
        {
            AddColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Categories", "CategoryName");
        }
    }
}
