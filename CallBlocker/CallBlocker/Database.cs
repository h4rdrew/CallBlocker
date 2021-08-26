using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CallBlocker
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<WhiteList>().Wait();
        }

        public Task<List<WhiteList>> GetNumberAsync()
        {
            return _database.Table<WhiteList>().ToListAsync();
        }

        public Task<int> SaveNumberAsync(WhiteList number)
        {
            return _database.InsertAsync(number);
        }
    }
}
