namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSupplierAndDepartmentModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Transaction", "Entry_SupplierID");
            CreateIndex("dbo.Transaction", "Exit_DepartmentID");
            AddForeignKey("dbo.Transaction", "Entry_SupplierID", "dbo.Supplier", "ID");
            AddForeignKey("dbo.Transaction", "Exit_DepartmentID", "dbo.Department", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "Exit_DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Transaction", "Entry_SupplierID", "dbo.Supplier");
            DropIndex("dbo.Transaction", new[] { "Exit_DepartmentID" });
            DropIndex("dbo.Transaction", new[] { "Entry_SupplierID" });
            DropTable("dbo.Department");
            DropTable("dbo.Supplier");
        }
    }
}
