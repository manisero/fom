namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItem_Remarks_and_Accepted_columns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Remarks", c => c.String());
            AddColumn("dbo.OrderItems", "Accepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "Accepted");
            DropColumn("dbo.OrderItems", "Remarks");
        }
    }
}
