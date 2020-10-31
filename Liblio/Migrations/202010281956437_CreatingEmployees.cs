namespace Liblio.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreatingEmployees : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "LibraryItem_Id", "dbo.LibraryItems");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropIndex("dbo.Rentals", new[] { "LibraryItem_Id" });
            CreateTable(
                "dbo.Employees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 255),
                    LastName = c.String(nullable: false, maxLength: 255),
                    Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    IsCEO = c.Boolean(nullable: false),
                    IsManager = c.Boolean(nullable: false),
                    ManagerId = c.Int(),
                })
                .PrimaryKey(t => t.Id);

            DropTable("dbo.Customers");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Rentals");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DateRented = c.DateTime(nullable: false),
                    DateReturned = c.DateTime(),
                    Customer_Id = c.Int(nullable: false),
                    LibraryItem_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.MembershipTypes",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(),
                    SignUpFee = c.Short(nullable: false),
                    DurationInMonths = c.Byte(nullable: false),
                    DiscountRate = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 255),
                    Birthdate = c.DateTime(),
                    IsSubscribedToNewsletter = c.Boolean(nullable: false),
                    MembershipTypeId = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            DropTable("dbo.Employees");
            CreateIndex("dbo.Rentals", "LibraryItem_Id");
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Rentals", "LibraryItem_Id", "dbo.LibraryItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
