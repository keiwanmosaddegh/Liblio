namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateMembershipTypes2 : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"
UPDATE MembershipTypes
SET Name = 'Monthly'
WHERE Id = 2;
"
                );
            Sql(
                @"
UPDATE MembershipTypes
SET Name = 'Quarterly'
WHERE Id = 3;
"
                );
            Sql(
                @"
UPDATE MembershipTypes
SET Name = 'Annually'
WHERE Id = 4;
"
                );
        }

        public override void Down()
        {
        }
    }
}
