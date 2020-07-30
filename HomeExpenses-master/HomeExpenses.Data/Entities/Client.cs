using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace HomeExpenses.Data
{
    public class Client : BaseEntity
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public DateTime CurrentMonth { get; set; }
        public decimal? MonthlyBudget { get; set; }
        public override void LoadData(SqlDataReader sqlDataReader)
        {
            ClientId = sqlDataReader.GetInt32(0);
            Name = sqlDataReader.GetString(1);
            CurrentMonth = sqlDataReader.GetDateTime(2);
            MonthlyBudget = sqlDataReader.GetDecimal(3);
        }
    }
}
