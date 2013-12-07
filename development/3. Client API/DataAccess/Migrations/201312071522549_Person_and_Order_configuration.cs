namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Person_and_Order_configuration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "RestaurantName", c => c.String(maxLength: 256));
            AlterColumn("dbo.Orders", "RestaurantAddress", c => c.String(maxLength: 512));
            AlterColumn("dbo.Orders", "RestaurantPhoneNumber", c => c.String(maxLength: 32));
            AlterColumn("dbo.Orders", "RestaurantEmailAddress", c => c.String(maxLength: 256));
            AlterColumn("dbo.Orders", "IntendedDeliveryTime", c => c.Time(precision: 7));
            AlterColumn("dbo.Orders", "Status", c => c.String(maxLength: 16));
            AlterColumn("dbo.People", "Name", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Name", c => c.String());
            AlterColumn("dbo.Orders", "Status", c => c.String());
            AlterColumn("dbo.Orders", "IntendedDeliveryTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Orders", "RestaurantEmailAddress", c => c.String());
            AlterColumn("dbo.Orders", "RestaurantPhoneNumber", c => c.String());
            AlterColumn("dbo.Orders", "RestaurantAddress", c => c.String());
            AlterColumn("dbo.Orders", "RestaurantName", c => c.String());
        }
    }
}
