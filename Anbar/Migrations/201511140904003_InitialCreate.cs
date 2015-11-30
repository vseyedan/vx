namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InventoryName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductInventory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        InventoryID = c.Int(nullable: false),
                        InventoryQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventory", t => t.InventoryID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.InventoryID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductCategoryID = c.Int(nullable: false),
                        ProductCode = c.String(),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        UnitID = c.Int(nullable: false),
                        StockLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Unit", t => t.UnitID, cascadeDelete: true)
                .Index(t => t.ProductCategoryID)
                .Index(t => t.UnitID);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TransactionDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TransactionID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PluMinusSign = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Transaction", t => t.TransactionID, cascadeDelete: true)
                .Index(t => t.TransactionID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TransactionType = c.Int(nullable: false),
                        TransactionNo = c.String(),
                        TransactionDate = c.String(),
                        Entry_SupplierID = c.Int(nullable: false),
                        Entry_InventoryID = c.Int(nullable: false),
                        Exit_DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UnitName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "UnitID", "dbo.Unit");
            DropForeignKey("dbo.TransactionDetail", "TransactionID", "dbo.Transaction");
            DropForeignKey("dbo.TransactionDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductInventory", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductCategoryID", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductInventory", "InventoryID", "dbo.Inventory");
            DropIndex("dbo.TransactionDetail", new[] { "ProductID" });
            DropIndex("dbo.TransactionDetail", new[] { "TransactionID" });
            DropIndex("dbo.Product", new[] { "UnitID" });
            DropIndex("dbo.Product", new[] { "ProductCategoryID" });
            DropIndex("dbo.ProductInventory", new[] { "InventoryID" });
            DropIndex("dbo.ProductInventory", new[] { "ProductID" });
            DropTable("dbo.Unit");
            DropTable("dbo.Transaction");
            DropTable("dbo.TransactionDetail");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.ProductInventory");
            DropTable("dbo.Inventory");
        }
    }
}
