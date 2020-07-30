using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeExpenses.Data
{
    public class ExpenseService : IDisposable
    {
        public async Task<List<Expense>> GetExpensesAsync()
        {
            return await Dal.GetAllAsync<Expense>("select * from Expense");
        }
        public async Task<List<ItemExpenses>> GetExpensesForDateAsync(DateTime currentDate)
        {
            var expensesList = await Dal.GetAllAsync<Expense>(string.Format("select e.*, i.Name ItemName, i.Price ItemPrice from Expense e inner join Item i on e.ItemId = i.ItemId where MONTH(RelateToMonth) = {0} AND YEAR(RelateToMonth) = {1}", currentDate.Month, currentDate.Year));
            var itemExpensesList = expensesList.GroupBy(a => new { a.ItemId, a.ItemName, a.ItemPrice }).Select(a => new ItemExpenses
            {
                ItemId = a.Key.ItemId ?? 0,
                ItemName = a.Key.ItemName,
                ItemPrice = a.Key.ItemPrice,
                ExpensesPrices = a.Where(i => i.Payed == true).Sum(i => i.Price),
                ItemExpensesList = a.ToList()
            }).ToList();
            return itemExpensesList;
        }

        public async Task<Expense> GetExpenseByIdAsync(int expenseId)
        {
            return await Dal.GetByIdAsync<Expense>("select * from Expense where ExpenseId = " + expenseId);
        }

        public void AddExpense(Expense expense)
        {
            Dal.Save(string.Format("INSERT INTO Expense (Name, ItemId, CreatedAt, UpdatedAt, Price, RelateToMonth, ClientId, Description, Payed) VALUES (N'{0}', {1}, N'{2}', N'{3}', {4}, N'{5}', {6}, N'{7}', N'{8}')",
                                        expense.Name, expense.ItemId, DateTime.Now, DateTime.Now, expense.Price, expense.RelateToMonth, expense.ClientId, expense.Description, expense.Payed));
        }

        public void UpdateExpense(Expense expense)
        {
            Dal.Save(string.Format("UPDATE Expense SET Name = N'{0}', ItemId = {1}, UpdatedAt = N'{2}', Price = {3}, RelateToMonth = N'{4}', ClientId = {5}, Description = N'{6}', Payed = N'{7}' WHERE ExpenseId = {8}",
                                        expense.Name, expense.ItemId, DateTime.Now, expense.Price, expense.RelateToMonth, expense.ClientId, expense.Description, expense.Payed, expense.ExpenseId));
        }

        public void UpdateCurrentMonth(DateTime currentDate, int clientId)
        {
            var items = Dal.GetAll<Item>("select i.* from Item i where i.DefaultIncluded = 1 and i.ClientId = " + clientId + " and (i.ItemTypeId = 1 or " +
                            "(i.ItemTypeId = 3  and DATEDIFF(MONTH, '" + currentDate + "', (select TOP 1 RelateToMonth from Expense e where e.ItemId = i.ItemId order by RelateToMonth desc)) = MonthsPeriod) or " +
                            "(i.ItemTypeId = 2  and DATEDIFF(MONTH, '" + currentDate + "', (select TOP 1 RelateToMonth from Expense e where e.ItemId = i.ItemId order by RelateToMonth desc)) = 12))");
            List<Expense> expenses = items.Select(i => new Expense
            {
                ClientId = clientId,
                ItemId = i.ItemId,
                Name = i.Name,
                Payed = false,
                RelateToMonth = currentDate,
                Price = i.Price
            }).ToList();
            expenses.ForEach(a => AddExpense(a));
            Dal.Save(string.Format("UPDATE Client SET CurrentMonth = '{0}' WHERE ClientId = {1}", currentDate, clientId));
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            await Dal.SaveAsync(string.Format("INSERT INTO Expense (Name, ItemId, CreatedAt, UpdatedAt, Price, RelateToMonth, ClientId, Description, Payed) VALUES (N'{0}', {1}, N'{2}', N'{3}', {4}, N'{5}', {6}, N'{7}', N'{8}')", 
                                        expense.Name, expense.ItemId, DateTime.Now, DateTime.Now, expense.Price, expense.RelateToMonth, expense.ClientId, expense.Payed, expense.Description));
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            await Dal.SaveAsync(string.Format("UPDATE Expense SET Name = N'{0}', ItemId = {1}, UpdatedAt = N'{2}', Price = {3}, RelateToMonth = N'{4}', ClientId = {5}, Description = N'{6}', Payed = N'{7}' WHERE ExpenseId = {8}",
                                        expense.Name, expense.ItemId, DateTime.Now, expense.Price, expense.RelateToMonth, expense.ClientId, expense.Description, expense.Payed, expense.ExpenseId));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
