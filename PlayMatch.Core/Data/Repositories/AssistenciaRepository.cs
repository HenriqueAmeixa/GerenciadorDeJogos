using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using SQLite;

namespace PlayMatch.Core.Data.Repositories
{
    public class AssistenciaRepository : SQLiteRepository<Assistencia>, IAssistenciaRepository
    {
        private readonly SQLiteAsyncConnection _database;
        public AssistenciaRepository(PlayMatchDbContext dbContext) : base(dbContext)
        {
            _database = dbContext.Database;
        }

        public async Task<List<Assistencia>> GetByPartidaIdAsync(int partidaId)
        {
            try
            {
                var assistencias = await _database.Table<Assistencia>().Where(g => g.PartidaId == partidaId).ToListAsync();
                return assistencias;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error fetching goals for PartidaId {partidaId}: {ex.Message}");
                return new List<Assistencia>();
            }
        }
    }
}
