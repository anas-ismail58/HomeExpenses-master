namespace HomeExpenses.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Add_Payed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expense", "Payed", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expense", "Payed");
        }
    }
}
