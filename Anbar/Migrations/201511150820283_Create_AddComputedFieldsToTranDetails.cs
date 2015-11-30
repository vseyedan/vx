namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_AddComputedFieldsToTranDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetail", "UnitPrice", c => c.Int(nullable: false));
            AddColumn("dbo.TransactionDetail", "ComputedTotalPrice", c => c.Long(nullable: false));
            AddColumn("dbo.TransactionDetail", "TotalPrice", c => c.Long(nullable: false));
            AddColumn("dbo.TransactionDetail", "ComputedUnitPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetail", "ComputedUnitPrice");
            DropColumn("dbo.TransactionDetail", "TotalPrice");
            DropColumn("dbo.TransactionDetail", "ComputedTotalPrice");
            DropColumn("dbo.TransactionDetail", "UnitPrice");
        }
    }
}
