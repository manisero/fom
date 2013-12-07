namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItems_entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemID = c.Int(nullable: false, identity: true),
                        DishName = c.String(maxLength: 512),
                        DishPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Order_OrderID = c.Int(),
                        Person_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderItemID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .ForeignKey("dbo.People", t => t.Person_PersonID)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Person_PersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.OrderItems", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Person_PersonID" });
            DropIndex("dbo.OrderItems", new[] { "Order_OrderID" });
            DropTable("dbo.OrderItems");
        }
    }
}
