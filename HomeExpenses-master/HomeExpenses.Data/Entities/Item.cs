using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace HomeExpenses.Data
{
    public class Item : BaseEntity
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ItemTypeId { get; set; }
        [ForeignKey(nameof(ItemTypeId))]
        public ItemType ItemType { get; set; }
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
        public bool DefaultIncluded { get; set; }
        public int MonthsPeriod { get; set; }
        public override void LoadData(SqlDataReader sqlDataReader)
        {
            ItemId = sqlDataReader.GetInt32(0);
            Name = sqlDataReader.GetString(1);
            Price = sqlDataReader.GetDecimal(2);
            ItemTypeId = sqlDataReader.GetInt32(3);
            ClientId = sqlDataReader.GetInt32(4);
            DefaultIncluded = sqlDataReader.GetBoolean(5);
            MonthsPeriod = sqlDataReader.GetInt32(6);
        }
    }
}
