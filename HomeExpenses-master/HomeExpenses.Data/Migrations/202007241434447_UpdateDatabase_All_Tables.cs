namespace HomeExpenses.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateDatabase_All_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CurrentMonth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.ItemType",
                c => new
                    {
                        ItemTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ItemTypeId);
            
            AddColumn("dbo.Item", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Item", "ItemTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Item", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.Item", "DefaultIncluded", c => c.Boolean(nullable: false));
            AddColumn("dbo.Item", "MonthsPeriod", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "ItemTypeId");
            CreateIndex("dbo.Item", "ClientId");
            AddForeignKey("dbo.Item", "ClientId", "dbo.Client", "ClientId", cascadeDelete: true);
            AddForeignKey("dbo.Item", "ItemTypeId", "dbo.ItemType", "ItemTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "ItemTypeId", "dbo.ItemType");
            DropForeignKey("dbo.Item", "ClientId", "dbo.Client");
            DropIndex("dbo.Item", new[] { "ClientId" });
            DropIndex("dbo.Item", new[] { "ItemTypeId" });
            DropColumn("dbo.Item", "MonthsPeriod");
            DropColumn("dbo.Item", "DefaultIncluded");
            DropColumn("dbo.Item", "ClientId");
            DropColumn("dbo.Item", "ItemTypeId");
            DropColumn("dbo.Item", "Price");
            DropTable("dbo.ItemType");
            DropTable("dbo.Client");
        }
    }
}
