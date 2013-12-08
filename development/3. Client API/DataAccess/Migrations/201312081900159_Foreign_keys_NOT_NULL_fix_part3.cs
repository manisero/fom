namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreign_keys_NOT_NULL_fix_part3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Payments", "Person_PersonID", "dbo.People");
            DropIndex("dbo.Payments", new[] { "Order_OrderID" });
            DropIndex("dbo.Payments", new[] { "Person_PersonID" });
            RenameColumn(table: "dbo.OrderItems", name: "Order_OrderID", newName: "OrderID");
            RenameColumn(table: "dbo.Payments", name: "Order_OrderID", newName: "OrderID");
            RenameColumn(table: "dbo.Payments", name: "Person_PersonID", newName: "PersonID");
            AlterColumn("dbo.Payments", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "OrderID");
            CreateIndex("dbo.Payments", "PersonID");
            AddForeignKey("dbo.Payments", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "PersonID", "dbo.People", "PersonID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "PersonID", "dbo.People");
            DropForeignKey("dbo.Payments", "OrderID", "dbo.Orders");
            DropIndex("dbo.Payments", new[] { "PersonID" });
            DropIndex("dbo.Payments", new[] { "OrderID" });
            AlterColumn("dbo.Payments", "OrderID", c => c.Int());
            RenameColumn(table: "dbo.Payments", name: "PersonID", newName: "Person_PersonID");
            RenameColumn(table: "dbo.Payments", name: "OrderID", newName: "Order_OrderID");
            RenameColumn(table: "dbo.OrderItems", name: "OrderID", newName: "Order_OrderID");
            CreateIndex("dbo.Payments", "Person_PersonID");
            CreateIndex("dbo.Payments", "Order_OrderID");
            AddForeignKey("dbo.Payments", "Person_PersonID", "dbo.People", "PersonID", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}
