namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IxCodeNameStrLengthTo70 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IxCode", "IxCodeName", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IxCode", "IxCodeName", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
