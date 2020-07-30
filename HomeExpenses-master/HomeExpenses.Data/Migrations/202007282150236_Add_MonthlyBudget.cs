namespace HomeExpenses.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Add_MonthlyBudget : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "MonthlyBudget", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "MonthlyBudget");
        }
    }
}
