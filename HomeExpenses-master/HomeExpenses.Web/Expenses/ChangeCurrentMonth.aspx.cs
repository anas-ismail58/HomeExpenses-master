using System;
using System.Globalization;
using System.Web.UI;
using HomeExpenses.Data;

namespace HomeExpenses.Web
{
    public partial class ChangeCurrentMonth : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                slcRelatedMonth.Value = Request.Cookies["ClientCurrentDate"].Value;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            using (var expenseService = new ExpenseService())
            {
                expenseService.UpdateCurrentMonth(DateTime.ParseExact(slcRelatedMonth.Value, "d-M-yyyy", CultureInfo.CurrentCulture), int.Parse(Request.Cookies["ClientId"].Value));
            }
            Response.RedirectPermanent(Request, "AllExpenses.aspx");
        }
    }
}