using PlayMatch.Core.Models;
using SQLite;
using System.Diagnostics;

namespace PlayMatch.Core.Data
{
    public class PlayMatchDbContext
    {
        private readonly SQLiteAsyncConnection _database;
        public const SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;
        public PlayMatchDbContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath, Flags);
            InitializeAsync().Wait();
        }

        private async Task InitializeAsync()
        {
            try
            {
                if (Database is not null)
                    return;
                var result = await _database.CreateTableAsync<Jogador>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao criar tabela: {ex.Message}");
            }
        }

        public SQLiteAsyncConnection Database => _database;
    }
}
