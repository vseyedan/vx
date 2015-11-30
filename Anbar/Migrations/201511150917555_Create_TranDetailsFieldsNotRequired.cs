namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_TranDetailsFieldsNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "Entry_SupplierID", c => c.Int());
            AlterColumn("dbo.Transaction", "Exit_DepartmentID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "Exit_DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "Entry_SupplierID", c => c.Int(nullable: false));
        }
    }
}
