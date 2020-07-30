using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.UI;
using HomeExpenses.Data;

namespace HomeExpenses.Web
{
    public partial class AddExpense : Page
    {
        public Expense CurrentExpense { get; set; }
        public List<Item> ItemsList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RegisterAsyncTask(new PageAsyncTask(Page_LoadAsync));
        }
        public async Task Page_LoadAsync()
        {
            CurrentExpense = new Expense();
            using (var itemService = new ItemService())
            {
                ItemsList = await itemService.GetItemsAsync();
                ItemsList.ForEach(a =>
                {
                    var listItem = new System.Web.UI.WebControls.ListItem(a.Name, a.ItemId.ToString());
                    slcItemId.Items.Add(listItem);
                    listItem.Attributes.Add("ItemTypeId", a.ItemTypeId.ToString());
                    listItem.Attributes.Add("Price", a.Price.ToString());
                    listItem.Attributes.Add("Name", a.Name);
                });
            }
            int expenseId;
            if (int.TryParse(Request.QueryString["ExpenseId"], out expenseId))
                using (var expenseService = new ExpenseService())
                {
                    CurrentExpense = await expenseService.GetExpenseByIdAsync(expenseId);
                    slcItemId.Value = CurrentExpense.ItemId.ToString();
                    txtName.Value = CurrentExpense.Name;
                    txtPrice.Value = CurrentExpense.Price.ToString();
                    slcRelatedMonth.Value = CurrentExpense.RelateToMonth.ToString("d-M-yyyy");
                    txtDescription.InnerText = CurrentExpense.Description;
                    chkPayed.Checked = CurrentExpense.Payed ?? false;
                }
            else
            {
                using (var clientService = new ClientService())
                {
                    var client = await clientService.GetClientByIdAsync(1);
                    slcRelatedMonth.Value = client.CurrentMonth.ToString("d-M-yyyy");
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            using (var expenseService = new ExpenseService())
            {
                CurrentExpense = new Expense();
                int expenseId;
                int.TryParse(Request.QueryString["ExpenseId"], out expenseId);
                CurrentExpense.ExpenseId = expenseId;
                CurrentExpense.Name = txtName.Value;
                CurrentExpense.Price = decimal.Parse(txtPrice.Value);
                CurrentExpense.RelateToMonth = DateTime.ParseExact(slcRelatedMonth.Value, "d-M-yyyy", CultureInfo.CurrentCulture);
                CurrentExpense.Description = txtDescription.Value;
                CurrentExpense.ItemId = int.Parse(slcItemId.Value);
                CurrentExpense.Payed = chkPayed.Checked;
                CurrentExpense.ClientId = int.Parse(Request.Cookies["ClientId"].Value);
                if (CurrentExpense.ExpenseId != 0)
                    expenseService.UpdateExpense(CurrentExpense);
                else
                    expenseService.AddExpense(CurrentExpense);
            }
            Response.RedirectPermanent(Request, "AllExpenses.aspx");
        }
    }
}