
using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using SQLite;

namespace PlayMatch.Core.Data.Repositories
{
    public class CampeonatoRepository:SQLiteRepository<Campeonato>, ICampeonatoRepository
    {
        private readonly SQLiteAsyncConnection _database;
        public CampeonatoRepository(PlayMatchDbContext dbContext) : base(dbContext)
        {
            _database = dbContext.Database;
        }
        public Task<List<Campeonato>> ObterTodosAsync()
          => _database.Table<Campeonato>().ToListAsync();

        public Task<Campeonato?> ObterPorIdAsync(int id)
            => _database.Table<Campeonato>().Where(c => c.Id == id).FirstOrDefaultAsync();

        public Task InserirAsync(Campeonato campeonato)
            => _database.InsertAsync(campeonato);

        public Task AtualizarAsync(Campeonato campeonato)
            => _database.UpdateAsync(campeonato);

        public Task RemoverAsync(int id)
            => _database.DeleteAsync<Campeonato>(id);
    }
}
