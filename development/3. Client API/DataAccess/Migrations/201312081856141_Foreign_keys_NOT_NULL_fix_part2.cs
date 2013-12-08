namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreign_keys_NOT_NULL_fix_part2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Owner_PersonID", "dbo.People");
            DropIndex("dbo.OrderItems", new[] { "Owner_PersonID" });
            RenameColumn(table: "dbo.OrderItems", name: "Owner_PersonID", newName: "OwnerID");
            AlterColumn("dbo.OrderItems", "OwnerID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "OwnerID");
            AddForeignKey("dbo.OrderItems", "OwnerID", "dbo.People", "PersonID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OwnerID", "dbo.People");
            DropIndex("dbo.OrderItems", new[] { "OwnerID" });
            AlterColumn("dbo.OrderItems", "OwnerID", c => c.Int());
            RenameColumn(table: "dbo.OrderItems", name: "OwnerID", newName: "Owner_PersonID");
            CreateIndex("dbo.OrderItems", "Owner_PersonID");
            AddForeignKey("dbo.OrderItems", "Owner_PersonID", "dbo.People", "PersonID");
        }
    }
}
