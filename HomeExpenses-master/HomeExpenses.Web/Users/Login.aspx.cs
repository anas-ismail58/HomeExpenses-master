using System;
using System.Web.UI;
using HomeExpenses.Data;

namespace HomeExpenses.Web
{
    public partial class Login : Page
    {
        public User CurrentUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            errorMessage.InnerText = "";
            // Method intentionally left empty.
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            using (var userService = new UserService())
            {
                CurrentUser = userService.GetUserByEmailAndPassword(txtEmail.Value, txtPassword.Value);
                if (CurrentUser == null)
                {
                    errorMessage.InnerText = "اسم المستخدم او كلمة المرور خطأ";
                }
                Response.Cookies.Clear();
                Response.Cookies.Add(new System.Web.HttpCookie("UserId", CurrentUser.UserId.ToString()));
                Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(3);
                Response.Cookies.Add(new System.Web.HttpCookie("ClientId", CurrentUser.ClientId.ToString()));
                Response.Cookies["ClientId"].Expires = DateTime.Now.AddDays(3);
                Response.Cookies.Add(new System.Web.HttpCookie("ClientCurrentDate", CurrentUser.ClientCurrentDate.ToString("d/M/yyyy")));
                Response.Cookies["ClientCurrentDate"].Expires = DateTime.Now.AddDays(3);
                Response.Cookies.Add(new System.Web.HttpCookie("MonthlyBudget", CurrentUser.MonthlyBugdet.ToString()));
                Response.Cookies["MonthlyBudget"].Expires = DateTime.Now.AddDays(3);
                Response.RedirectPermanent("/Expenses/AllExpenses.aspx", true);
            }
        }
    }
}