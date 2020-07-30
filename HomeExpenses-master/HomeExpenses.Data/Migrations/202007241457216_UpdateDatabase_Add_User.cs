namespace HomeExpenses.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateDatabase_Add_User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ItemId = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RelateToMonth = c.DateTime(nullable: false),
                        ClientId = c.Int(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.Client", t => t.ClientId)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .Index(t => t.ItemId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Expense", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Expense", "ClientId", "dbo.Client");
            DropIndex("dbo.User", new[] { "ClientId" });
            DropIndex("dbo.Expense", new[] { "ClientId" });
            DropIndex("dbo.Expense", new[] { "ItemId" });
            DropTable("dbo.User");
            DropTable("dbo.Expense");
        }
    }
}
