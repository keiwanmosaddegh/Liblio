namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Genres : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"
INSERT INTO Genres (Name)
VALUES
(
'Comedy'
),
(
'Action'
),
(
'Family'
),
(
'Romance'
);
"
                );
        }

        public override void Down()
        {
        }
    }
}
