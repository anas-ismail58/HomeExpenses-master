namespace HomeExpenses.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial_Creation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Item");
        }
    }
}
