using System.Collections.Generic;

namespace HomeExpenses.Data
{
    public class ItemExpenses
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal ExpensesPrices { get; set; }
        public List<Expense> ItemExpensesList { get; set; }
    }
}
