using PlayMatch.Core.Models;

namespace PlayMatch.Core.Data.Interfaces
{
    public interface IPartidaRepository : IGenericRepository<Partida>
    {
        Task<List<Partida>> ObterPorRodadaIdAsync(int rodadaId);
        Task<List<Partida>> GetByRodadasAsync(List<int> rodadaIds);
    }
}
