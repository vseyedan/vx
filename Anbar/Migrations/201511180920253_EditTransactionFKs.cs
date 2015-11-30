namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTransactionFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "Entry_SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Transaction", "Exit_DepartmentID", "dbo.Department");
            DropIndex("dbo.Transaction", new[] { "Entry_SupplierID" });
            DropIndex("dbo.Transaction", new[] { "Exit_DepartmentID" });
            AddColumn("dbo.Transaction", "Entry_Suppliers_ID", c => c.Int());
            AddColumn("dbo.Transaction", "Exit_Departments_ID", c => c.Int());
            CreateIndex("dbo.Transaction", "Entry_Suppliers_ID");
            CreateIndex("dbo.Transaction", "Exit_Departments_ID");
            AddForeignKey("dbo.Transaction", "Entry_Suppliers_ID", "dbo.Supplier", "ID");
            AddForeignKey("dbo.Transaction", "Exit_Departments_ID", "dbo.Department", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "Exit_Departments_ID", "dbo.Department");
            DropForeignKey("dbo.Transaction", "Entry_Suppliers_ID", "dbo.Supplier");
            DropIndex("dbo.Transaction", new[] { "Exit_Departments_ID" });
            DropIndex("dbo.Transaction", new[] { "Entry_Suppliers_ID" });
            DropColumn("dbo.Transaction", "Exit_Departments_ID");
            DropColumn("dbo.Transaction", "Entry_Suppliers_ID");
            CreateIndex("dbo.Transaction", "Exit_DepartmentID");
            CreateIndex("dbo.Transaction", "Entry_SupplierID");
            AddForeignKey("dbo.Transaction", "Exit_DepartmentID", "dbo.Department", "ID");
            AddForeignKey("dbo.Transaction", "Entry_SupplierID", "dbo.Supplier", "ID");
        }
    }
}
