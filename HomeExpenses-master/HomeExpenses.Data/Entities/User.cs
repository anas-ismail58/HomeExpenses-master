using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace HomeExpenses.Data
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
        [NotMapped]
        public DateTime ClientCurrentDate { get; set; }
        [NotMapped]
        public decimal MonthlyBugdet { get; set; }
        public override void LoadData(SqlDataReader sqlDataReader)
        {
            UserId = sqlDataReader.GetInt32(0);
            Name = sqlDataReader.GetString(1);
            Email = sqlDataReader.GetString(2);
            Password = sqlDataReader.GetString(3);
            ClientId = sqlDataReader.GetInt32(4);
            if (sqlDataReader.FieldCount > 5)
            {
                ClientCurrentDate = sqlDataReader.GetDateTime(5);
                MonthlyBugdet = sqlDataReader.GetDecimal(6);
            }
        }
    }
}
