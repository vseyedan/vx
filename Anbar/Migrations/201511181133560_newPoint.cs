namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newPoint : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IxCode",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IxCodeName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Product", "IxCodeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "IxCodeID");
            AddForeignKey("dbo.Product", "IxCodeID", "dbo.IxCode", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "IxCodeID", "dbo.IxCode");
            DropIndex("dbo.Product", new[] { "IxCodeID" });
            DropColumn("dbo.Product", "IxCodeID");
            DropTable("dbo.IxCode");
        }
    }
}
