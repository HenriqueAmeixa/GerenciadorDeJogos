using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using SQLite;
namespace PlayMatch.Core.Data.Repositories
{
    public class GolRepository : SQLiteRepository<Gol>, IGolRepository
    {
        private readonly SQLiteAsyncConnection _database;
        public GolRepository(PlayMatchDbContext dbContext) : base(dbContext)
        {
            _database = dbContext.Database;
        }

        public async Task<List<Gol>> GetByPartidaIdAsync(int partidaId)
        {
            try
            {
                var gols = await _database.Table<Gol>().Where(g => g.PartidaId == partidaId).ToListAsync();
                return gols ?? new List<Gol>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching goals for PartidaId {partidaId}: {ex.Message}");
                return new List<Gol>();
            }
        }
    }
}
