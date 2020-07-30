using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using HomeExpenses.Data;

namespace HomeExpenses.Web
{
    public partial class AllExpenses : Page
    {
        public List<ItemExpenses> ItemExpensesList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(Page_LoadAsync));
        }
        public async Task Page_LoadAsync()
        {
            using (var expenseService = new ExpenseService())
            {
                ItemExpensesList = await expenseService.GetExpensesForDateAsync(DateTime.ParseExact(Request.Cookies["ClientCurrentDate"].Value, "d/M/yyyy", CultureInfo.CurrentCulture));
                var itemExpensesPrices = ItemExpensesList.Sum(a => a.ExpensesPrices);
                lblTotalPayed.InnerText = itemExpensesPrices.ToString();
                lblRest.InnerText = (decimal.Parse(Request.Cookies["MonthlyBudget"].Value) - itemExpensesPrices).ToString();
            }
        }
    }
}