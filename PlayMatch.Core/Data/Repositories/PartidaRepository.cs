using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using SQLite;

namespace PlayMatch.Core.Data.Repositories
{
    public class PartidaRepository : SQLiteRepository<Partida>, IPartidaRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public PartidaRepository(PlayMatchDbContext dbContext) : base(dbContext)
        {
            _database = dbContext.Database;
        }

        public Task<List<Partida>> ObterPorRodadaIdAsync(int rodadaId)
        {
            return _database.Table<Partida>()
                      .Where(p => p.RodadaId == rodadaId)
                      .ToListAsync();
        }
        public async Task<List<Partida>> GetByRodadasAsync(List<int> rodadaIds)
        {
            if (rodadaIds == null || !rodadaIds.Any())
                return new List<Partida>();

            return await _database
                .Table<Partida>()
                .Where(p => rodadaIds.Contains(p.RodadaId))
                .ToListAsync();
        }
    }
}
