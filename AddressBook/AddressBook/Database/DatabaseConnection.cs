using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AddressBook.Database
{
    public class DatabaseConnection
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseConnection(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ContactInfo>().Wait();
        }

        public Task<List<ContactInfo>> GetContactInfosAsync()
        {
            return _database.Table<ContactInfo>().ToListAsync();
        }

        public Task<ContactInfo> GetContactInfoAsync(int id)
        {
            return _database.Table<ContactInfo>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveContactInfoAsync(ContactInfo contactInfo)
        {
            return contactInfo.ID != 0 ? _database.UpdateAsync(contactInfo) : _database.InsertAsync(contactInfo);
        }

        public Task<int> DeleteContactInfoAsync(ContactInfo contactInfo)
        {
            return _database.DeleteAsync(contactInfo);
        }
    }
}
