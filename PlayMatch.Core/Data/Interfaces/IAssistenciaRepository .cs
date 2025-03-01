using PlayMatch.Core.Models;

namespace PlayMatch.Core.Data.Interfaces
{
    public interface IAssistenciaRepository : IGenericRepository<Assistencia>
    {
        Task<List<Assistencia>> GetByPartidaIdAsync(int partidaId);
    }
}
