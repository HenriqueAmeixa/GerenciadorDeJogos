using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using SQLite;

namespace PlayMatch.Core.Data.Repositories
{
    public class JogadorRepository : SQLiteRepository<Jogador>, IJogadorRepository
    {
        private readonly SQLiteAsyncConnection _database;
        public JogadorRepository(PlayMatchDbContext dbContext) : base(dbContext)
        {
            _database = dbContext.Database;
        }
        public async Task<List<Jogador>> GetByCampeonatoAsync(int campeonatoId)
        {
            var query = @"
            SELECT DISTINCT j.Id, j.Nome, j.Apelido
            FROM Partida p
            JOIN Time t1 ON p.Time1Id = t1.Id
            JOIN Time t2 ON p.Time2Id = t2.Id
            JOIN TimeJogador tj1 ON tj1.TimeId = t1.Id
            JOIN TimeJogador tj2 ON tj2.TimeId = t2.Id
            JOIN Jogador j ON j.Id = tj1.JogadorId OR j.Id = tj2.JogadorId
            WHERE p.RodadaId IN (
                SELECT Id FROM Rodada WHERE CampeonatoId = ?
            )
        ";

            var jogadores = await _database.QueryAsync<Jogador>(query, campeonatoId);
            return jogadores.DistinctBy(j => j.Id).OrderBy(j => j.Apelido).ToList();
        }
    }
}
