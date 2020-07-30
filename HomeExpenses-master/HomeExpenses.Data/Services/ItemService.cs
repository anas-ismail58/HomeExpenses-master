using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeExpenses.Data
{
    public class ItemService : IDisposable
    {
        public async Task<List<Item>> GetItemsAsync()
        {
            return await Dal.GetAllAsync<Item>("select * from Item");
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            return await Dal.GetByIdAsync<Item>("select * from Item where ItemId = " + itemId);
        }

        public void AddItem(Item item)
        {
            Dal.Save(string.Format("INSERT INTO ITEM (Name, Price, ItemTypeId, ClientId, DefaultIncluded, MonthsPeriod) VALUES (N'{0}', {1}, {2}, {3}, N'{4}', {5})",
                                        item.Name, item.Price, item.ItemTypeId, item.ClientId, item.DefaultIncluded, item.MonthsPeriod));
        }

        public void UpdateItem(Item item)
        {
            Dal.Save(string.Format("UPDATE ITEM SET Name = N'{0}', Price = {1}, ItemTypeId = {2}, ClientId = {3}, DefaultIncluded = N'{4}', MonthsPeriod = {5} WHERE ItemId = {6}",
                                        item.Name, item.Price, item.ItemTypeId, item.ClientId, item.DefaultIncluded, item.MonthsPeriod, item.ItemId));
        }

        public async Task AddItemAsync(Item item)
        {
            await Dal.SaveAsync(string.Format("INSERT INTO ITEM (Name, Price, ItemTypeId, ClientId, DefaultIncluded, MonthsPeriod) VALUES (N'{0}', {1}, {2}, {3}, N'{4}', {5})", 
                                        item.Name, item.Price, item.ItemTypeId, item.ClientId, item.DefaultIncluded, item.MonthsPeriod));
        }

        public async Task UpdateItemAsync(Item item)
        {
            await Dal.SaveAsync(string.Format("UPDATE ITEM SET Name = N'{0}', Price = {1}, ItemTypeId = {2}, ClientId = {3}, DefaultIncluded = N'{4}', MonthsPeriod = {5} WHERE ItemId = {6}",
                                        item.Name, item.Price, item.ItemTypeId, item.ClientId, item.DefaultIncluded, item.MonthsPeriod, item.ItemId));
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
