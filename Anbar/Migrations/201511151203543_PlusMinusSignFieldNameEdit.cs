namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlusMinusSignFieldNameEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetail", "PlusMinusSign", c => c.Boolean(nullable: false));
            DropColumn("dbo.TransactionDetail", "PluMinusSign");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionDetail", "PluMinusSign", c => c.Boolean(nullable: false));
            DropColumn("dbo.TransactionDetail", "PlusMinusSign");
        }
    }
}
