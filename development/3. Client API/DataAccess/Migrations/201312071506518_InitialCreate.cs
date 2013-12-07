namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        RestaurantName = c.String(),
                        RestaurantAddress = c.String(),
                        RestaurantPhoneNumber = c.String(),
                        RestaurantEmailAddress = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        IntendedDeliveryTime = c.Time(nullable: false, precision: 7),
                        Status = c.String(),
                        Owner_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.People", t => t.Owner_PersonID)
                .Index(t => t.Owner_PersonID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Owner_PersonID", "dbo.People");
            DropIndex("dbo.Orders", new[] { "Owner_PersonID" });
            DropTable("dbo.People");
            DropTable("dbo.Orders");
        }
    }
}
