using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace HomeExpenses.Data
{
    public class Expense : BaseEntity
    {
        [Key]
        public int ExpenseId { get; set; }
        public string Name { get; set; }
        public int? ItemId { get; set; }
        [ForeignKey(nameof(ItemId))]
        public Item Item { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal Price { get; set; }
        public DateTime RelateToMonth { get; set; }
        public int? ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
        public string Description { get; set; }
        public bool? Payed { get; set; }
        [NotMapped]
        public string ItemName { get; set; }
        [NotMapped]
        public decimal ItemPrice { get; set; }
        public override void LoadData(SqlDataReader sqlDataReader)
        {
            ExpenseId = sqlDataReader.GetInt32(0);
            Name = sqlDataReader.GetString(1);
            ItemId = sqlDataReader.GetInt32(2);
            CreatedAt = sqlDataReader.GetDateTime(3);
            UpdatedAt = sqlDataReader.GetDateTime(4);
            Price = sqlDataReader.GetDecimal(5);
            RelateToMonth = sqlDataReader.GetDateTime(6);
            ClientId = sqlDataReader.GetInt32(7);
            Description = sqlDataReader.GetString(8);
            Payed = sqlDataReader.GetBoolean(9);
            if (sqlDataReader.FieldCount > 10)
            {
                ItemName = sqlDataReader.GetString(10);
                ItemPrice = sqlDataReader.GetDecimal(11);
            }
        }
    }
}
