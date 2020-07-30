using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeExpenses.Data
{
    public class ClientService : IDisposable
    {
        public async Task<List<Client>> GetClientsAsync()
        {
            return await Dal.GetAllAsync<Client>("select * from Client");
        }

        public async Task<Client> GetClientByIdAsync(int clientId)
        {
            return await Dal.GetByIdAsync<Client>("select * from Client where ClientId = " + clientId);
        }

        public async Task AddClientAsync(Client client)
        {
            await Dal.SaveAsync(string.Format("INSERT INTO ITEM (Name, CurrentMonth) VALUES ('{0}', '{1}')", 
                                        client.Name, DateTime.Now));
        }

        public async Task UpdateClientAsync(Client client)
        {
            await Dal.SaveAsync(string.Format("UPDATE Client SET Name = '{0}', CurrentMonth = '{1}' WHERE ClientId = {2}",
                                        client.Name, DateTime.Now, client.ClientId));
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
