namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedManagerToEmployee : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Employees", "ManagerId");
            AddForeignKey("dbo.Employees", "ManagerId", "dbo.Employees", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ManagerId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "ManagerId" });
        }
    }
}
