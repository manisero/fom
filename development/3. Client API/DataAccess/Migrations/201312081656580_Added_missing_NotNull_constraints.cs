namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_missing_NotNull_constraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderItems", "DishName", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.Orders", "RestaurantName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Name", c => c.String(maxLength: 256));
            AlterColumn("dbo.Orders", "RestaurantName", c => c.String(maxLength: 256));
            AlterColumn("dbo.OrderItems", "DishName", c => c.String(maxLength: 512));
        }
    }
}
