using System.Data.SqlClient;

namespace HomeExpenses.Data
{
    public class BaseEntity
    {
        public virtual void LoadData(SqlDataReader sqlDataReader)
        { 
        }
    }
}
