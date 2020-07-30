using System;
using System.Threading.Tasks;
using System.Web.UI;
using HomeExpenses.Data;

namespace HomeExpenses.Web
{
    public partial class AddItem : Page
    {
        public Item CurrentItem { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RegisterAsyncTask(new PageAsyncTask(Page_LoadAsync));
        }
        public async Task Page_LoadAsync()
        {
            CurrentItem = new Item();
            int itemId;
            if (int.TryParse(Request.QueryString["ItemId"], out itemId))
                using (var itemService = new ItemService())
                {
                    CurrentItem = await itemService.GetItemByIdAsync(itemId);
                    txtName.Value = CurrentItem.Name;
                    txtPrice.Value = CurrentItem.Price.ToString();
                    slcItemType.Value = CurrentItem.ItemTypeId.ToString();
                    chkDefaultIncluded.Checked = CurrentItem.DefaultIncluded;
                    txtMonthsPeriod.Value = CurrentItem.MonthsPeriod.ToString();
                }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            using (var itemService = new ItemService())
            {
                CurrentItem = new Item();
                int itemId;
                int.TryParse(Request.QueryString["ItemId"], out itemId);
                CurrentItem.ItemId = itemId;
                CurrentItem.Name = txtName.Value;
                CurrentItem.Price = decimal.Parse(txtPrice.Value);
                CurrentItem.ItemTypeId = int.Parse(slcItemType.Value);
                CurrentItem.DefaultIncluded = chkDefaultIncluded.Checked;
                CurrentItem.MonthsPeriod = int.Parse(txtMonthsPeriod.Value);
                CurrentItem.ClientId = int.Parse(Request.Cookies["ClientId"].Value);
                if (CurrentItem.ItemId != 0)
                    itemService.UpdateItem(CurrentItem);
                else
                    itemService.AddItem(CurrentItem);
            }
            Response.RedirectPermanent(Request, "AllItems.aspx");
        }
    }
}