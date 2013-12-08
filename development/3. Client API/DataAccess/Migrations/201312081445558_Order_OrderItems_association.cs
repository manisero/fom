namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order_OrderItems_association : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Person_PersonID", "dbo.People");
            DropIndex("dbo.OrderItems", new[] { "Person_PersonID" });
            AddColumn("dbo.OrderItems", "Owner_PersonID", c => c.Int());
            CreateIndex("dbo.OrderItems", "Owner_PersonID");
            AddForeignKey("dbo.OrderItems", "Owner_PersonID", "dbo.People", "PersonID");
            DropColumn("dbo.OrderItems", "Person_PersonID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "Person_PersonID", c => c.Int());
            DropForeignKey("dbo.OrderItems", "Owner_PersonID", "dbo.People");
            DropIndex("dbo.OrderItems", new[] { "Owner_PersonID" });
            DropColumn("dbo.OrderItems", "Owner_PersonID");
            CreateIndex("dbo.OrderItems", "Person_PersonID");
            AddForeignKey("dbo.OrderItems", "Person_PersonID", "dbo.People", "PersonID");
        }
    }
}
