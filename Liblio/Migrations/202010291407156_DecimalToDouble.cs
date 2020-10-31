namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DecimalToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Salary", c => c.Double(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Employees", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
