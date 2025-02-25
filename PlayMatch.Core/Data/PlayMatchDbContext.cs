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
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            try
            {
                var resultJogador = await _database.CreateTableAsync<Jogador>();
                var resultPartida = await _database.CreateTableAsync<Partida>();
                var resultTime = await _database.CreateTableAsync<Time>();
                var resultGol = await _database.CreateTableAsync<Gol>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao criar tabela: {ex.Message}");
            }
        }

        public SQLiteAsyncConnection Database => _database;
    }
}
