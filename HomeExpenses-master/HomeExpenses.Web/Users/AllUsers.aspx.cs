using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;
using HomeExpenses.Data;

namespace HomeExpenses.Web
{
    public partial class AllUsers : Page
    {
        public List<User> UsersList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(Page_LoadAsync));
        }
        public async Task Page_LoadAsync()
        {
            using (var userService = new UserService())
            {
                UsersList = await userService.GetUsersAsync();
            }
        }
    }
}