using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using SQLite;

namespace PlayMatch.Core.Data.Repositories
{
    public class RodadaRepository : SQLiteRepository<Rodada>, IRodadaRepository
    {
        private readonly SQLiteAsyncConnection _database;
        public RodadaRepository(PlayMatchDbContext dbContext) : base(dbContext)
        {
            _database = dbContext.Database;
        }
        public Task<List<Rodada>> ObterPorCampeonatoIdAsync(int campeonatoId)
        => _database.Table<Rodada>().Where(r => r.CampeonatoId == campeonatoId).ToListAsync();

        public Task<Rodada?> ObterPorIdAsync(int id)
            => _database.Table<Rodada>().Where(r => r.Id == id).FirstOrDefaultAsync();

        public Task InserirAsync(Rodada rodada)
            => _database.InsertAsync(rodada);

        public Task AtualizarAsync(Rodada rodada)
            => _database.UpdateAsync(rodada);

        public Task RemoverAsync(int id)
            => _database.DeleteAsync<Rodada>(id);
    }
}
