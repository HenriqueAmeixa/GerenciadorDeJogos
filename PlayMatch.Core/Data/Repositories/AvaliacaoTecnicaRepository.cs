using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models.Jogadores;
using SQLite;

namespace PlayMatch.Core.Data.Repositories
{
    public class AvaliacaoTecnicaRepository : SQLiteRepository<AvaliacaoTecnica>, IAvaliacaoTecnicaRepository
    {
        private readonly SQLiteAsyncConnection _database;
        public AvaliacaoTecnicaRepository(PlayMatchDbContext dbContext) : base(dbContext)
        {
            _database = dbContext.Database;
        }
        public async Task InserirAsync(AvaliacaoTecnica avaliacao)
        {
            await _database.InsertAsync(avaliacao);
        }
        public async Task<List<AvaliacaoTecnica>> ObterPorJogadorAsync(int jogadorId)
        {
            return await _database.Table<AvaliacaoTecnica>()
                .Where(a => a.JogadorId == jogadorId)
                .ToListAsync();
        }
        public async Task<AvaliacaoTecnica?> ObterUltimaPorJogadorAsync(int jogadorId)
        {
            return await _database.Table<AvaliacaoTecnica>()
                .Where(a => a.JogadorId == jogadorId)
                .OrderByDescending(a => a.DataAvaliacao)
                .FirstOrDefaultAsync();
        }
        public async Task<List<AvaliacaoTecnica>> ObterPorCampeonatoAsync(int campeonatoId)
        {
            return await _database.Table<AvaliacaoTecnica>()
                .Where(a => a.CampeonatoId == campeonatoId)
                .ToListAsync();
        }
        public async Task<AvaliacaoTecnica?> ObterUltimaPorJogadorECampeonatoAsync(int jogadorId, int campeonatoId)
        {
            return await _database.Table<AvaliacaoTecnica>()
                .Where(a => a.JogadorId == jogadorId && a.CampeonatoId == campeonatoId)
                .OrderByDescending(a => a.DataAvaliacao)
                .FirstOrDefaultAsync();
        }

        public async Task DeletarAsync(int avaliacaoId)
        {
            await _database.DeleteAsync<AvaliacaoTecnica>(avaliacaoId);
        }
    }
}
