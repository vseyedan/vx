namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShamsiTransactionDateandSupplierFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "Description", c => c.String(maxLength: 200));
            AddColumn("dbo.Supplier", "Phone", c => c.String(maxLength: 20));
            AddColumn("dbo.Supplier", "Address", c => c.String(maxLength: 250));
            AlterColumn("dbo.Transaction", "TransactionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "TransactionDate", c => c.Int(nullable: false));
            DropColumn("dbo.Supplier", "Address");
            DropColumn("dbo.Supplier", "Phone");
            DropColumn("dbo.Transaction", "Description");
        }
    }
}
