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
                await _database.CreateTableAsync<Jogador>();
                await _database.CreateTableAsync<Partida>();
                await _database.CreateTableAsync<Time>();
                await _database.CreateTableAsync<Gol>();
                await _database.CreateTableAsync<Assistencia>();
                await _database.CreateTableAsync<TimeJogador>();
                await _database.CreateTableAsync<Configuracao>();
                await _database.CreateTableAsync<Campeonato>();
                await _database.CreateTableAsync<Rodada>();

                var configExistente = await _database.Table<Configuracao>()
                .FirstOrDefaultAsync(c => c.Chave == "tempo_partida");

                if (configExistente == null)
                {
                    await _database.InsertAsync(new Configuracao
                    {
                        Chave = "tempo_partida",
                        Valor = TimeSpan.FromMinutes(7).ToString(),
                        Tipo = "timespan"
                    });
                }

                var configManterVencedores = await _database.Table<Configuracao>()
                .FirstOrDefaultAsync(c => c.Chave == "manter_vencedores");

                if (configManterVencedores == null)
                {
                    await _database.InsertAsync(new Configuracao
                    {
                        Chave = "manter_vencedores",
                        Valor = "false",
                        Tipo = "bool"
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao criar tabela: {ex.Message}");
            }
        }

        public SQLiteAsyncConnection Database => _database;
    }
}
