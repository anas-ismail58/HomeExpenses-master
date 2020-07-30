using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HomeExpenses.Data
{
    public class AppDBContext : DbContext
    {

        public AppDBContext() : base("DefaultConnectionString")
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
