namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UndoTransactionFKs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transaction", "Entry_SupplierID");
            DropColumn("dbo.Transaction", "Exit_DepartmentID");
            RenameColumn(table: "dbo.Transaction", name: "Entry_Suppliers_ID", newName: "Entry_SupplierID");
            RenameColumn(table: "dbo.Transaction", name: "Exit_Departments_ID", newName: "Exit_DepartmentID");
            RenameIndex(table: "dbo.Transaction", name: "IX_Entry_Suppliers_ID", newName: "IX_Entry_SupplierID");
            RenameIndex(table: "dbo.Transaction", name: "IX_Exit_Departments_ID", newName: "IX_Exit_DepartmentID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Transaction", name: "IX_Exit_DepartmentID", newName: "IX_Exit_Departments_ID");
            RenameIndex(table: "dbo.Transaction", name: "IX_Entry_SupplierID", newName: "IX_Entry_Suppliers_ID");
            RenameColumn(table: "dbo.Transaction", name: "Exit_DepartmentID", newName: "Exit_Departments_ID");
            RenameColumn(table: "dbo.Transaction", name: "Entry_SupplierID", newName: "Entry_Suppliers_ID");
            AddColumn("dbo.Transaction", "Exit_DepartmentID", c => c.Int());
            AddColumn("dbo.Transaction", "Entry_SupplierID", c => c.Int());
        }
    }
}
