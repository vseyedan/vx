namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTranDetailsAddInventoryField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetail", "InventoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.TransactionDetail", "InventoryID");
            AddForeignKey("dbo.TransactionDetail", "InventoryID", "dbo.Inventory", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionDetail", "InventoryID", "dbo.Inventory");
            DropIndex("dbo.TransactionDetail", new[] { "InventoryID" });
            DropColumn("dbo.TransactionDetail", "InventoryID");
        }
    }
}
