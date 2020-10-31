namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"
UPDATE MembershipTypes
SET Name = 'Pay As You Go'
WHERE Id = 1;
"
                );
        }

        public override void Down()
        {
        }
    }
}
