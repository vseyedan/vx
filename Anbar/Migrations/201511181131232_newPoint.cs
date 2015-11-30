namespace Anbar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newPoint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "IndexCodeID", "dbo.IndexCode");
            DropIndex("dbo.Product", new[] { "IndexCodeID" });
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
            DropColumn("dbo.Product", "IndexCodeID");
            DropTable("dbo.IndexCode");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IndexCode",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IndexCodeName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Product", "IndexCodeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Product", "IxCodeID", "dbo.IxCode");
            DropIndex("dbo.Product", new[] { "IxCodeID" });
            DropColumn("dbo.Product", "IxCodeID");
            DropTable("dbo.IxCode");
            CreateIndex("dbo.Product", "IndexCodeID");
            AddForeignKey("dbo.Product", "IndexCodeID", "dbo.IndexCode", "ID", cascadeDelete: true);
        }
    }
}
