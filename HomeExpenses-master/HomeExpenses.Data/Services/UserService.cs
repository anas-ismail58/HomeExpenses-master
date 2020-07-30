using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeExpenses.Data
{
    public class UserService : IDisposable
    {
        public async Task<List<User>> GetUsersAsync()
        {
            return await Dal.GetAllAsync<User>("select * from [User]");
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await Dal.GetByIdAsync<User>("select * from [User] where UserId = " + userId);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await Dal.GetByIdAsync<User>("select * from [User] where Email = '" + email + "' AND Password = '" + password + "'");
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return Dal.GetById<User>("select u.*, c.CurrentMonth, c.MonthlyBudget from [User] as u inner join client as c on u.ClientId = c.ClientId where Email = '" + email + "' AND Password = '" + password + "'");
        }

        public void AddUser(User user)
        {
            Dal.Save(string.Format("INSERT INTO [User] (Name, Email, Password, ClientId) VALUES (N'{0}', N'{1}', N'{2}', {3})",
                                        user.Name, user.Email, user.Password, user.ClientId));
        }

        public void UpdateUser(User user)
        {
            Dal.Save(string.Format("UPDATE [User] SET Name = N'{0}', Email = N'{1}', Password = N'{2}', ClientId = {3} WHERE UserId = {4}",
                                        user.Name, user.Email, user.Password, user.ClientId, user.UserId));
        }

        public async Task AddUserAsync(User user)
        {
            await Dal.SaveAsync(string.Format("INSERT INTO [User] (Name, Email, Password, ClientId) VALUES (N'{0}', N'{1}', N'{2}', {3})",
                                        user.Name, user.Email, user.Password, user.ClientId));
        }

        public async Task UpdateUserAsync(User user)
        {
            await Dal.SaveAsync(string.Format("UPDATE [User] SET Name = N'{0}', Email = N'{1}', Password = N'{2}', ClientId = {3} WHERE UserId = {4}",
                                        user.Name, user.Email, user.Password, user.ClientId, user.UserId));
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
