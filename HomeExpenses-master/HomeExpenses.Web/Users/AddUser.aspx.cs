using System;
using System.Threading.Tasks;
using System.Web.UI;
using HomeExpenses.Data;

namespace HomeExpenses.Web
{
    public partial class AddUser : Page
    {
        public User CurrentUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RegisterAsyncTask(new PageAsyncTask(Page_LoadAsync));
        }
        public async Task Page_LoadAsync()
        {
            CurrentUser = new User();
            int userId;
            if (int.TryParse(Request.QueryString["UserId"], out userId))
                using (var userService = new UserService())
                {
                    CurrentUser = await userService.GetUserByIdAsync(userId);
                    txtName.Value = CurrentUser.Name;
                    txtEmail.Value = CurrentUser.Email;
                    txtPassword.Value = CurrentUser.Password;
                }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            using (var userService = new UserService())
            {
                CurrentUser = new User();
                int userId;
                int.TryParse(Request.QueryString["UserId"], out userId);
                CurrentUser.UserId = userId;
                CurrentUser.Name = txtName.Value;
                CurrentUser.Email = txtEmail.Value;
                CurrentUser.Password = txtPassword.Value;
                CurrentUser.ClientId = int.Parse(Request.Cookies["ClientId"].Value);
                if (CurrentUser.UserId != 0)
                    userService.UpdateUser(CurrentUser);
                else
                    userService.AddUser(CurrentUser);
            }
            Response.RedirectPermanent(Request, "AllUsers.aspx");
        }
    }
}