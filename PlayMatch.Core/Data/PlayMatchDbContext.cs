using PlayMatch.Core.Models;
using SQLite;

namespace PlayMatch.Core.Data
{
    public class PlayMatchDbContext
    {
        private readonly SQLiteAsyncConnection _database;

        public PlayMatchDbContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            InitializeAsync().Wait();
        }

        private async Task InitializeAsync()
        {
            await _database.CreateTableAsync<Jogador>();
        }

        public SQLiteAsyncConnection Database => _database;
    }
}
