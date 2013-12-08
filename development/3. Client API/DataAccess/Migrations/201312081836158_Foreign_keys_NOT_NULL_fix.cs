namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreign_keys_NOT_NULL_fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Owner_PersonID", "dbo.People");
            DropForeignKey("dbo.Payments", "Person_PersonID", "dbo.People");
            DropIndex("dbo.OrderItems", new[] { "Order_OrderID" });
            DropIndex("dbo.Orders", new[] { "Owner_PersonID" });
            DropIndex("dbo.Payments", new[] { "Person_PersonID" });
            AlterColumn("dbo.OrderItems", "Order_OrderID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Owner_PersonID", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "Person_PersonID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "Order_OrderID");
            CreateIndex("dbo.Orders", "Owner_PersonID");
            CreateIndex("dbo.Payments", "Person_PersonID");
            AddForeignKey("dbo.OrderItems", "Order_OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Owner_PersonID", "dbo.People", "PersonID", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "Person_PersonID", "dbo.People", "PersonID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.Orders", "Owner_PersonID", "dbo.People");
            DropForeignKey("dbo.OrderItems", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.Payments", new[] { "Person_PersonID" });
            DropIndex("dbo.Orders", new[] { "Owner_PersonID" });
            DropIndex("dbo.OrderItems", new[] { "Order_OrderID" });
            AlterColumn("dbo.Payments", "Person_PersonID", c => c.Int());
            AlterColumn("dbo.Orders", "Owner_PersonID", c => c.Int());
            AlterColumn("dbo.OrderItems", "Order_OrderID", c => c.Int());
            CreateIndex("dbo.Payments", "Person_PersonID");
            CreateIndex("dbo.Orders", "Owner_PersonID");
            CreateIndex("dbo.OrderItems", "Order_OrderID");
            AddForeignKey("dbo.Payments", "Person_PersonID", "dbo.People", "PersonID");
            AddForeignKey("dbo.Orders", "Owner_PersonID", "dbo.People", "PersonID");
            AddForeignKey("dbo.OrderItems", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}
