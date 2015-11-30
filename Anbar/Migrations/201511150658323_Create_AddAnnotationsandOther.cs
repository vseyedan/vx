namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_AddAnnotationsandOther : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventory", "InventoryName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Inventory", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Product", "ProductCode", c => c.String(maxLength: 20));
            AlterColumn("dbo.Product", "ProductName", c => c.String(maxLength: 60));
            AlterColumn("dbo.Product", "ProductDescription", c => c.String(maxLength: 100));
            AlterColumn("dbo.ProductCategory", "CategoryName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Transaction", "TransactionNo", c => c.String(nullable: false));
            AlterColumn("dbo.Transaction", "TransactionDate", c => c.String(nullable: false));
            AlterColumn("dbo.Unit", "UnitName", c => c.String(nullable: false, maxLength: 15));
            DropColumn("dbo.Transaction", "Entry_InventoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "Entry_InventoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Unit", "UnitName", c => c.String());
            AlterColumn("dbo.Transaction", "TransactionDate", c => c.String());
            AlterColumn("dbo.Transaction", "TransactionNo", c => c.String());
            AlterColumn("dbo.ProductCategory", "CategoryName", c => c.String());
            AlterColumn("dbo.Product", "ProductDescription", c => c.String());
            AlterColumn("dbo.Product", "ProductName", c => c.String());
            AlterColumn("dbo.Product", "ProductCode", c => c.String());
            AlterColumn("dbo.Inventory", "Description", c => c.String());
            AlterColumn("dbo.Inventory", "InventoryName", c => c.String());
        }
    }
}
