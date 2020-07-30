using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HomeExpenses.Data
{
    public static class Dal
    {
        public static string ConnectionString { get { return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString; } }
        public static async Task<List<T>> GetAllAsync<T>(string commandString) where T : BaseEntity
        {
            List<T> entities = new List<T>();
            using (SqlCommand sqlCommand = new SqlCommand(commandString, new SqlConnection(ConnectionString)))
            {
                await sqlCommand.Connection.OpenAsync();
                var reader = await sqlCommand.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var entity = (T)Activator.CreateInstance(typeof(T));
                    entity.LoadData(reader);
                    entities.Add(entity);
                }
                sqlCommand.Connection.Close();
            }
            return entities;
        }

        public static List<T> GetAll<T>(string commandString) where T : BaseEntity
        {
            List<T> entities = new List<T>();
            using (SqlCommand sqlCommand = new SqlCommand(commandString, new SqlConnection(ConnectionString)))
            {
                sqlCommand.Connection.Open();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var entity = (T)Activator.CreateInstance(typeof(T));
                    entity.LoadData(reader);
                    entities.Add(entity);
                }
                sqlCommand.Connection.Close();
            }
            return entities;
        }

        public static async Task<T> GetByIdAsync<T>(string commandString) where T : BaseEntity
        {
            var entity = (T)Activator.CreateInstance(typeof(T));
            using (SqlCommand sqlCommand = new SqlCommand(commandString, new SqlConnection(ConnectionString)))
            {
                await sqlCommand.Connection.OpenAsync();
                var reader = await sqlCommand.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    entity.LoadData(reader);
                }
                sqlCommand.Connection.Close();
            }
            return entity;
        }

        public static T GetById<T>(string commandString) where T : BaseEntity
        {
            var entity = (T)Activator.CreateInstance(typeof(T));
            using (SqlCommand sqlCommand = new SqlCommand(commandString, new SqlConnection(ConnectionString)))
            {
                sqlCommand.Connection.Open();
                var reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    entity.LoadData(reader);
                }
                sqlCommand.Connection.Close();
            }
            return entity;
        }

        public static void Save(string commandString)
        {
            using (SqlCommand sqlCommand = new SqlCommand(commandString, new SqlConnection(ConnectionString)))
            {
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
            }
        }

        public static async Task SaveAsync(string commandString)
        {
            using (SqlCommand sqlCommand = new SqlCommand(commandString, new SqlConnection(ConnectionString)))
            {
                await sqlCommand.Connection.OpenAsync();
                await sqlCommand.ExecuteNonQueryAsync();
                sqlCommand.Connection.Close();
            }
        }
    }
}
