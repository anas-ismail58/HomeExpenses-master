using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;
using HomeExpenses.Data;

namespace HomeExpenses.Web
{
    public partial class AllItems : Page
    {
        public List<Item> ItemsList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(Page_LoadAsync));
        }
        public async Task Page_LoadAsync()
        {
            using (var itemService = new ItemService())
            {
                ItemsList = await itemService.GetItemsAsync();
            }
        }
    }
}