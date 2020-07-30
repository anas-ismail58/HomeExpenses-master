using System;
using System.Web.UI;

namespace HomeExpenses.Web
{
    public partial class Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["ClientId"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("login.aspx");
        }
    }
}