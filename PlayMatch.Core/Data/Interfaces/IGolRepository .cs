using PlayMatch.Core.Models;

namespace PlayMatch.Core.Data.Interfaces
{
    public interface IGolRepository : IGenericRepository<Gol>
    {
        Task<List<Gol>> GetByPartidaIdAsync(int partidaId);
    }
}
