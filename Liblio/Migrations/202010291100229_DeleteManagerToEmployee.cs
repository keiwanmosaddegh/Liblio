namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DeleteManagerToEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "ManagerId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "ManagerId" });
        }

        public override void Down()
        {
            CreateIndex("dbo.Employees", "ManagerId");
            AddForeignKey("dbo.Employees", "ManagerId", "dbo.Employees", "Id");
        }
    }
}
