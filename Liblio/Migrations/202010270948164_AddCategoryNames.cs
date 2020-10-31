namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCategoryNames : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO Categories
(CategoryName)
VALUES
('Comedy');

INSERT INTO Categories
(CategoryName)
VALUES
('Family');

INSERT INTO Categories
(CategoryName)
VALUES
('Romance');

INSERT INTO Categories
(CategoryName)
VALUES
('Non Fiction');
");
        }

        public override void Down()
        {
        }
    }
}
