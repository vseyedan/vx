namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_TranDetailsTranDateToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "TransactionDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "TransactionDate", c => c.String(nullable: false));
        }
    }
}
