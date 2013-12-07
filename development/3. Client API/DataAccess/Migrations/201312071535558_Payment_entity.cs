namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Payment_entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_OrderID = c.Int(),
                        Person_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .ForeignKey("dbo.People", t => t.Person_PersonID)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Person_PersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.Payments", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.Payments", new[] { "Person_PersonID" });
            DropIndex("dbo.Payments", new[] { "Order_OrderID" });
            DropTable("dbo.Payments");
        }
    }
}
